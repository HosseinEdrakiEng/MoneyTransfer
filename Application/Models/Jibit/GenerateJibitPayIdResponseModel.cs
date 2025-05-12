using Application.Common;
using System.Text.Json.Serialization;

namespace Application.Models.Jibit
{
    public class GenerateJibitPayIdRequestModel
    {
        public string CallbackUrl { get; set; }
        public string MerchantReferenceNumber { get; set; }
        public string UserFullName { get; set; }
        public List<string> UserIbans { get; set; }
        public string UserMobile { get; set; }
        public string UserRedirectUrl { get; set; }
    }
    public class GenerateJibitPayIdResponseModel
    {
        [JsonPropertyName("destinationBank")]
        public string DestinationBank { get; set; }

        [JsonPropertyName("destinationDepositNumber")]
        public string DestinationDepositNumber { get; set; }

        [JsonPropertyName("destinationIban")]
        public string DestinationIban { get; set; }

        [JsonPropertyName("destinationOwnerName")]
        public string DestinationOwnerName { get; set; }

        [JsonPropertyName("failReason")]
        public string FailReason { get; set; }

        [JsonPropertyName("merchantCode")]
        public string MerchantCode { get; set; }

        [JsonPropertyName("merchantName")]
        public string MerchantName { get; set; }

        [JsonPropertyName("merchantReferenceNumber")]
        public string MerchantReferenceNumber { get; set; }

        [JsonPropertyName("payId")]
        public string PayId { get; set; }

        [JsonPropertyName("registryStatus")]
        public RegistryStatus RegistryStatus { get; set; }

        [JsonPropertyName("userFullName")]
        public string UserFullName { get; set; }

        [JsonPropertyName("userIban")]
        public string UserIban { get; set; }

        [JsonPropertyName("userIbans")]
        public List<string> UserIbans { get; set; }

        [JsonPropertyName("userMobile")]
        public string UserMobile { get; set; }

        [JsonPropertyName("userToken")]
        public string UserToken { get; set; }
    }
}
