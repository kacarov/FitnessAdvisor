using App.Data.Contracts;
using App.Data.Repositories;

namespace App.Data
{
    public class DbContext : IDbContext
    {
        public DbContext()
        {
            this.UserRepository = new UserRepository();
        }

        public UserRepository UserRepository { get; set; }
    }
}
