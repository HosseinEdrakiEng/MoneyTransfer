using Application.Common;

namespace Application.Models
{
    public class InquiryTransferResponseModel
    {
        public string BatchId { get; set; }
        public string ClientBatchId { get; set; }

        public List<InquiryTransferDetailResponseModel> Transfers { get; set; }
    }
    public class InquiryTransferDetailResponseModel
    {
        public string ReferenceId { get; set; }
        public string ClientReferenceId { get; set; }
        public TransferDetailStatus Status { get; set; }
    }
}
