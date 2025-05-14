using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.Api.Models
{
    public class TransferRequestDto
    {
        [Required]
        public string ClientBatchId { get; set; }

        public DateTime? SendTime { get; set; }

        [Required]
        public List<TransferDetailRequestDto> Transfers { get; set; }
    }
    public class TransferDetailRequestDto
    {
        [Required]
        public string ClientReferenceId { get; set; }

        [Required]
        [RegularExpression(@"^IR\d{22}$", ErrorMessage = "Iban must start with 'IR' and be 22 characters")]
        public string Iban { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        public long Amount { get; set; }
    }
}
