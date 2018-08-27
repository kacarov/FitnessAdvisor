using App.Data.Repositories;

namespace App.Data.Contracts
{
    public interface IDbContext
    {
        IUserRepository UserRepository { get; }
    }
}