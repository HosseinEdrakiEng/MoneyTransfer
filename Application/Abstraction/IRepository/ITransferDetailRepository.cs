using Application.Models;
using Domain.Entites;

namespace Application.Abstraction.IRepository
{
    public interface ITransferDetailRepository
    {
        Task ChangeStatus(List<TransferDetail> items, CancellationToken cancellationToken);
        Task<TransferDetail> FindByClientclientReferenceId(string clientReferenceId, CancellationToken cancellationToken);
    }
}
