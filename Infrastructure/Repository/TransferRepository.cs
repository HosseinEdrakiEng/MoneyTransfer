using Application.Abstraction.IRepository;
using Domain.Entites;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly MoneyTransferDbContext _context;

        public TransferRepository(MoneyTransferDbContext context)
        {
            _context = context;
        }

        public async Task Create(Transfer model, CancellationToken cancellationToken)
        {
            _context.Transfers.Add(model);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Transfer> FindByBatchId(string batchId, CancellationToken cancellationToken)
        {
            return await _context.Transfers.Include(r => r.Details).Where(r => r.BatchId == batchId)?.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Transfer> FindByClientBatchId(string clientBatchId, CancellationToken cancellationToken)
        {
            return await _context.Transfers.Include(r => r.Details).Where(r => r.ClientBatchId == clientBatchId)?.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
