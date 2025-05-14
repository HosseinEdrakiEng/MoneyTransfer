using Application.Abstraction.IRepository;
using Domain.Entites;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TransferDetailRepository : ITransferDetailRepository
    {
        private readonly MoneyTransferDbContext _context;

        public TransferDetailRepository(MoneyTransferDbContext context)
        {
            _context = context;
        }

        public async Task ChangeStatus(List<TransferDetail> items, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TransferDetail> FindByClientclientReferenceId(string clientReferenceId, CancellationToken cancellationToken)
        {
            return await _context.TransferDetails.Where(r => r.ClientReferenceId == clientReferenceId)?.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
