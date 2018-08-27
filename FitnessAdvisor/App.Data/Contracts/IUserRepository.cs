using App.Data.Entities;
using System.Collections.Generic;

namespace App.Data.Contracts
{
    public interface IUserRepository
    {
        IUserEntitie GetById(int id);

        IList<IUserEntitie> GetAllUsers();

        void Add(IUserEntitie entity);

        void Delete(IUserEntitie entity);

        void DeleteById(int id);

        void Update(IUserEntitie entity);
    }
}
