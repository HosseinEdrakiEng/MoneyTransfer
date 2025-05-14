namespace Domain.Entites
{
    public class Transfer
    {
        public long Id { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string ClientBatchId { get; set; }
        public string BatchId { get; set; } = Guid.NewGuid().ToString("N");
        public string? Description { get; set; }

        public string ClientId { get; set; }
        public string UserId { get; set; }
        public DateTime? SendTime { get; set; }

        public virtual ICollection<TransferDetail> Details { get; set; }
    }
}
