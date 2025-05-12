using System.Text.Json.Serialization;

namespace Application.Models.Jibit
{
    public class InquiryJibitPayIdResponseModel
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("bank")]
        public string Bank { get; set; }

        [JsonPropertyName("bankReferenceNumber")]
        public string BankReferenceNumber { get; set; }

        [JsonPropertyName("destinationAccountIdentifier")]
        public string DestinationAccountIdentifier { get; set; }

        [JsonPropertyName("externalReferenceNumber")]
        public string ExternalReferenceNumber { get; set; }

        [JsonPropertyName("merchantReferenceNumber")]
        public string MerchantReferenceNumber { get; set; }

        [JsonPropertyName("paymentId")]
        public string PaymentId { get; set; }

        [JsonPropertyName("rawBankTimestamp")]
        public string RawBankTimestamp { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
