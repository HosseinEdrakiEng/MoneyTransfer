using System.Text.Json.Serialization;

namespace Application.Models.Jibit
{
    public class GenerateJibitTokenResponseModel
    {
        [JsonPropertyName("accessToken")]
        public string accessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public string refreshToken { get; set; }
    }
}
