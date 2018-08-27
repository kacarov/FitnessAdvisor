using App.Data.Contracts;
using System;
using System.Collections.Generic;

namespace FitnessAdvisor.Tests.App.Core.Services.Mocks
{
    public class UserRepositoryMock : IUserRepository
    {
        public UserRepositoryMock()
        {
            this.FakeLiteDb = new List<IUserEntitie>();
        }

        public List<IUserEntitie> FakeLiteDb { get; private set; }

        public void Add(IUserEntitie entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("User cannot be null!");
            }
            this.FakeLiteDb.Add(entity);
        }

        public void Delete(IUserEntitie entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<IUserEntitie> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IUserEntitie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IUserEntitie entity)
        {
            var user = this.FakeLiteDb.Find(u => u.Username == entity.Username);

            this.FakeLiteDb.Remove(user);
            this.FakeLiteDb.Add(entity);
        }
    }
}
