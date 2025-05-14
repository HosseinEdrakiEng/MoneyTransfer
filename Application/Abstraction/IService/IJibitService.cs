using Application.Models.Jibit;
using Helper;

namespace Application.Abstraction.IService
{
    public interface IJibitService
    {
        Task<BaseResponse<GenerateJibitPayIdResponseModel>> GeneratePayId(GenerateJibitPayIdRequestModel request, CancellationToken cancellationToken);
        Task<BaseResponse<GenerateJibitPayIdResponseModel>> PayIdInfo(string merchantRefrenceNumber, CancellationToken cancellationToken);
        Task<BaseResponse<InquiryJibitPayIdResponseModel>> PayIdInquiry(string externalRefrenceNumber, CancellationToken cancellationToken);
        Task<BaseResponse<VerifyJibitPayIdResponseModel>> PayIdVerify(string externalRefrenceNumber, CancellationToken cancellationToken);
        Task<BaseResponse<FailJibitPayIdResponseModel>> PayIdFail(string externalRefrenceNumber, CancellationToken cancellationToken);
        Task<BaseResponse<JibitTransferResponseModel>> Transfer(JibitTransferRequestModel request, CancellationToken cancellationToken);
        Task<BaseResponse<JibitInquiryTransferResponseModel>> InquiryTransfer(string? batchId, string? transferId, CancellationToken cancellationToken);
        Task<BaseResponse<JibitDeleteTransferResponseModel>> DeleteTransfer(string? batchId, string? transferId, CancellationToken cancellationToken);
        Task<BaseResponse<JibitRetryTransferResponseModel>> RetryTransfer(string? batchId, string? transferId, CancellationToken cancellationToken);
    }
}
