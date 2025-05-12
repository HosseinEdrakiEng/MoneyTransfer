using Application.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class MoneyTransferDbContext : DbContext, IMoneyTransferDbContext
    {
    }
}
