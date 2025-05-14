namespace Application.Common
{
    public class JibitConfig
    {
        public string BaseUrl { get; set; }
        public TimeSpan Timeout { get; set; }
        public string GenerateTokenUrl { get; set; }
        public string SecretKey { get; set; }
        public string ApiKey { get; set; }
        public string GeneratePayIdUrl { get; set; }
        public string PayIdInfoUrl { get; set; }
        public string PayIdInquiryUrl { get; set; }
        public string PayIdVerifyUrl { get; set; }
        public string PayIdFailUrl { get; set; }
        public string TransferUrl { get; set; }
        public string InquiryTransferUrl { get; set; }
    }
}
