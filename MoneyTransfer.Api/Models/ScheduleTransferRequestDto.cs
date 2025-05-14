using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.Api.Models
{
    public class ScheduleTransferRequestDto
    {
        [Required]
        public string BatchId { get; set; }
    }
}
