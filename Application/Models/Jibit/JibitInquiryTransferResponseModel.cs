using System.Text.Json.Serialization;

namespace Application.Models.Jibit
{
    public class JibitInquiryTransferResponseModel
    {
        [JsonPropertyName("batchID")]
        public string BatchId { get; set; }

        [JsonPropertyName("transfers")]
        public List<JibitInquiryTransferModel> Transfers { get; set; }
    }
    public class JibitInquiryTransferModel : JibitTransferModel
    {
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("failReason")]
        public string FailReason { get; set; }

        [JsonPropertyName("channelManagerProcessingType")]
        public string ChannelManagerProcessingType { get; set; }

        [JsonPropertyName("bankSubmittedTime")]
        public string BankSubmittedTime { get; set; }

        [JsonPropertyName("feeCurrency")]
        public string FeeCurrency { get; set; }

        [JsonPropertyName("feeAmount")]
        public long FeeAmount { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("modifiedAt")]
        public string ModifiedAt { get; set; }
    }
}
