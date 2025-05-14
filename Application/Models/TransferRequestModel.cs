using Application.Common;

namespace Application.Models
{
    public class TransferRequestModel
    {
        public string ClientBatchId { get; set; }
        public DateTime? SendTime { get; set; }
        public List<TransferDetailRequestModel> Transfers { get; set; }
    }
    public class TransferDetailRequestModel
    {
        public string ClientReferenceId { get; set; }
        public string Iban { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long Amount { get; set; }
    }
    public class TransferResponseModel
    {
        public string ClientBatchId { get; set; }
        public string BatchId { get; set; }
        public List<TransferDetailResponseModel> Transfers { get; set; }
    }
    public class TransferDetailResponseModel
    {
        public string ClientReferenceId { get; set; }
        public string ReferenceId { get; set; }
        public TransferDetailStatus Status { get; set; }
    }
}
