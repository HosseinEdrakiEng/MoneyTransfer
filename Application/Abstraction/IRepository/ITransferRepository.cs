using Domain.Entites;

namespace Application.Abstraction.IRepository
{
    public interface ITransferRepository
    {
        Task Create(Transfer model, CancellationToken cancellationToken);
        Task<Transfer> FindByBatchId(string batchId, CancellationToken cancellationToken);
        Task<Transfer> FindByClientBatchId(string clientBatchId, CancellationToken cancellationToken);
    }
}
