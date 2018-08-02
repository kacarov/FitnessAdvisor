using App.Data.Entities;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace App.Data.Repositories
{
    public class UserRepository 
    {
        private const string connectionString = @"../../../NewDb.db";

        public UserEntitie GetById(int id)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<UserEntitie>(typeof(UserEntitie).Name);
                return collection.FindById(id);
            }
        }

        public IList<UserEntitie> GetAllUsers()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<UserEntitie>(typeof(UserEntitie).Name);
                IEnumerable<UserEntitie> output = collection.FindAll();
                return output.ToList();
            }
        }

        public void Add(UserEntitie entity)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<UserEntitie>(typeof(UserEntitie).Name);

                collection.Insert(collection.Max("_id").AsInt32 + 1, entity);
            }
        }


        public void Delete(UserEntitie entity)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<UserEntitie>(typeof(UserEntitie).Name);

                collection.Delete(u => u == entity);
            }
        }

        public void DeleteById(int id)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<UserEntitie>(typeof(UserEntitie).Name);

                collection.Delete(u => u.UserId == id);
            }
        }

        public void Update(UserEntitie entity)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<UserEntitie>(typeof(UserEntitie).Name);

                collection.Update(entity);
            }
        }
    }
}
