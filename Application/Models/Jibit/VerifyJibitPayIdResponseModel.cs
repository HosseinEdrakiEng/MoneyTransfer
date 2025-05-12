using System.Text.Json.Serialization;

namespace Application.Models.Jibit
{
    public class VerifyJibitPayIdResponseModel
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("amountLimiterType")]
        public string AmountLimiterType { get; set; }

        [JsonPropertyName("bank")]
        public string Bank { get; set; }

        [JsonPropertyName("bankReferenceNumber")]
        public string BankReferenceNumber { get; set; }

        [JsonPropertyName("batchId")]
        public string BatchId { get; set; }

        [JsonPropertyName("destinationAccountIdentifier")]
        public string DestinationAccountIdentifier { get; set; }

        [JsonPropertyName("externalReferenceNumber")]
        public string ExternalReferenceNumber { get; set; }

        [JsonPropertyName("merchantReferenceNumber")]
        public string MerchantReferenceNumber { get; set; }

        [JsonPropertyName("partNo")]
        public int PartNo { get; set; }

        [JsonPropertyName("paymentId")]
        public string PaymentId { get; set; }

        [JsonPropertyName("rawBankTimestamp")]
        public string RawBankTimestamp { get; set; }

        [JsonPropertyName("sourceIdentifier")]
        public string SourceIdentifier { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("totalAmount")]
        public int TotalAmount { get; set; }
    }
}