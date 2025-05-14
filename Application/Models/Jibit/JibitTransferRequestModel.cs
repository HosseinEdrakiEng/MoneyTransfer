using System.Text.Json.Serialization;

namespace Application.Models.Jibit
{
    public class JibitTransferRequestModel
    {
        public string BatchId { get; set; }
        public string SubmissionMode { get; set; }
        public List<JibitTransferModel> Transfers { get; set; } = [];
    }
    public class JibitTransferResponseModel
    {
        [JsonPropertyName("submittedCount")]
        public int SubmittedCount { get; set; }

        [JsonPropertyName("totalAmountTransferred")]
        public long TotalAmountTransferred { get; set; }

        [JsonPropertyName("rejections")]
        public List<JibitTransferModel> Rejections { get; set; } = [];
    }
    public class JibitTransferModel
    {
        public string TransferId { get; set; }
        public string? TransferMode { get; set; } = "ACH";
        public string Destination { get; set; }
        public string? DestinationFirstName { get; set; }
        public string? DestinationLastName { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; } = "RIALS";
        public string? Description { get; set; }
        public string? Metadata { get; set; }
        public string? NotifyURL { get; set; }
        public bool Cancellable { get; set; } = true;
        public string? PaymentId { get; set; }
    }
}
