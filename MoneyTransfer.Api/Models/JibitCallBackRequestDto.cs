namespace MoneyTransfer.Api.Models
{
    public class JibitCallBackRequestDto
    {
        public string ExternalRefrenceNumber { get; set; }
        public string Status { get; set; }
        public string Bank { get; set; }
        public string BankRefrenceNumber { get; set; }
        public string PaymentId { get; set; }
        public string Amount { get; set; }
        public string DestinationAccountIdentifier { get; set; }
        public string RawBankTimestamp { get; set; }
    }
}
