namespace Domain.Entites
{
    public class TransferDetail
    {
        public long Id { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public string ClientReferenceId { get; set; }
        public string ReferenceId { get; set; } = Guid.NewGuid().ToString("N");

        public long TransferId { get; set; }
        public Transfer Transfer { get; set; }

        public byte Status { get; set; } = 0;
        public DateTime? LastAttemptTime { get; set; }
        public int? RetryCount { get; set; }
        public string? Description { get; set; }

        public string Iban { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long Amount { get; set; }
    }
}
