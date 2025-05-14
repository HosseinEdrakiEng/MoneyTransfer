using Application.Abstraction.IRepository;
using Application.Abstraction.IService;
using Application.Common;
using Application.Models;
using Application.Models.Hangfire;
using Application.Models.Jibit;
using Domain.Entites;
using Helper;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Service
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly ITransferDetailRepository _transferDetailRepository;
        private readonly IJibitService _jibitService;
        private readonly IHangfireService _hangfireServie;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TransferService(ITransferRepository transferRepository
            , IJibitService jibitService
            , IHangfireService hangfireServie
            , IHttpContextAccessor httpContextAccessor)
        {
            _transferRepository = transferRepository;
            _jibitService = jibitService;
            _hangfireServie = hangfireServie;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse<InquiryTransferResponseModel>> Inquiry(string clientBatchId, CancellationToken cancellationToken)
        {
            var result = new BaseResponse<InquiryTransferResponseModel>();

            var trans = await _transferRepository.FindByClientBatchId(clientBatchId, cancellationToken);
            if (trans is null)
            {
                result.Error = CustomError.InvalidClientBatchId;
                return result;
            }

            result.Data = new InquiryTransferResponseModel
            {
                BatchId = trans.BatchId,
                ClientBatchId = clientBatchId,
                Transfers = trans.Details.Adapt<List<InquiryTransferDetailResponseModel>>()
            };
            return result;
        }

        public async Task<BaseResponse<ScheduleTransferResponseModel>> ScheduleTransfer(ScheduleTransferRequestModel request, CancellationToken cancellationToken)
        {
            var result = new BaseResponse<ScheduleTransferResponseModel>();

            var models = await _transferRepository.FindByBatchId(request.BatchId, cancellationToken);
            if (models is null)
            {
                result.Error = CustomError.TransferModelNotFound;
                return result;
            }

            var succ = await TransferItems(models, cancellationToken);
            if (!succ)
            {
                result.Error = CustomError.JibitTransferFail;
                return result;
            }

            return result;

        }

        public async Task<BaseResponse<TransferResponseModel>> Transfer(TransferRequestModel request, CancellationToken cancellationToken)
        {
            var result = new BaseResponse<TransferResponseModel>();

            var model = request.Adapt<Transfer>();
            model.Details = request.Transfers.Adapt<List<TransferDetail>>();

            await _transferRepository.Create(model, cancellationToken);

            if (!request.SendTime.HasValue)
            {
                var succ = await TransferItems(model, cancellationToken);
                if (!succ)
                {
                    result.Error = CustomError.JibitTransferFail;
                    return result;
                }
            }
            else
            {
                var ipAddress = _httpContextAccessor.HttpContext.Connection.LocalIpAddress?.ToString();
                var port = _httpContextAccessor.HttpContext.Connection.LocalPort;

                var hangfireResponse = await _hangfireServie.ScheduleJob(new ScheduleJobRequestModel 
                { 
                    EnqueueAt = request.SendTime.Value, 
                    Model = new { bachId = model.BatchId }, 
                    Url = $"{ipAddress}:{port}/api/v1/transfer/schedule-transfer" 
                }, cancellationToken);

                if (hangfireResponse.HasError)
                {
                    result.Error = hangfireResponse.Error;
                    return result;
                }
            }

            result.Data = new TransferResponseModel
            {
                ClientBatchId = model.ClientBatchId,
                BatchId = model.BatchId,
                Transfers = model.Details.Adapt<List<TransferDetailResponseModel>>()
            };

            return result;
        }

        private async Task<bool> TransferItems(Transfer model, CancellationToken cancellationToken)
        {
            var jibitModel = new JibitTransferRequestModel
            {
                BatchId = model.BatchId,
                Transfers = model.Details.Adapt<List<JibitTransferModel>>()
            };
            var jibitResponse = await _jibitService.Transfer(jibitModel, cancellationToken);
            if (jibitResponse.HasError)
            {
                return false;
            }

            var rejectedIds = jibitResponse.Data.Rejections.Where(r => !string.IsNullOrEmpty(r.TransferId)).Select(r => r.TransferId).ToHashSet();
            foreach (var detail in model.Details)
            {
                if (!string.IsNullOrEmpty(detail.ReferenceId) && rejectedIds.Contains(detail.ReferenceId))
                {
                    detail.Status = (byte)TransferDetailStatus.Retry;
                }
                else
                {
                    detail.Status = (byte)TransferDetailStatus.Success;
                }
                detail.LastAttemptTime = DateTime.Now;
                detail.RetryCount = !detail.RetryCount.HasValue ? 1 : detail.RetryCount.Value + 1;
            }

            await _transferDetailRepository.ChangeStatus([.. model.Details], cancellationToken);

            return true;
        }
    }
}