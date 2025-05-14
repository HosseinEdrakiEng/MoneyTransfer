using Application.Models;
using Helper;

namespace Application.Abstraction.IService
{
    public interface ITransferService
    {
        Task<BaseResponse<InquiryTransferResponseModel>> Inquiry(string clientBatchId, CancellationToken cancellationToken);
        Task<BaseResponse<ScheduleTransferResponseModel>> ScheduleTransfer(ScheduleTransferRequestModel request, CancellationToken cancellationToken);
        Task<BaseResponse<TransferResponseModel>> Transfer(TransferRequestModel request, CancellationToken cancellationToken);
    }
}
