using App.Data.Contracts;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace App.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string connectionString = @"../../../NewDb.db";

        public IUserEntitie GetById(int id)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<IUserEntitie>(typeof(IUserEntitie).Name);
                return collection.FindById(id);
            }
        }

        public IList<IUserEntitie> GetAllUsers()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<IUserEntitie>(typeof(IUserEntitie).Name);
                IEnumerable<IUserEntitie> output = collection.FindAll();
                return output.ToList();
            }
        }

        public void Add(IUserEntitie entity)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<IUserEntitie>(typeof(IUserEntitie).Name);

                collection.Insert(collection.Max("_id").AsInt32 + 1, entity);
            }
        }

        public void Delete(IUserEntitie entity)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<IUserEntitie>(typeof(IUserEntitie).Name);

                collection.Delete(u => u == entity);
            }
        }

        public void DeleteById(int id)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<IUserEntitie>(typeof(IUserEntitie).Name);

                collection.Delete(u => u.UserId == id);
            }
        }

        public void Update(IUserEntitie entity)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<IUserEntitie>(typeof(IUserEntitie).Name);

                collection.Update(entity);
            }
        }
    }
}
