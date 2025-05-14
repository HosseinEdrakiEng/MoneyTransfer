using Application.Abstraction;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class MoneyTransferDbContext : DbContext, IMoneyTransferDbContext
    {
        public MoneyTransferDbContext()
        {
            
        }

        public MoneyTransferDbContext(DbContextOptions<MoneyTransferDbContext> options)
            : base(options)
        {

        }

        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<TransferDetail> TransferDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new OtpConfiguration());
        }
    }
}
