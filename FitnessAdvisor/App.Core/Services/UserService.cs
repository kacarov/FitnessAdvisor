using App.Data;
using App.Data.Entities;
using System;
using System.Linq;

namespace App.Core.Services
{
    public class UserService
    {
        private DbContext db;

        public UserService(DbContext db)
        {
            this.db = db;
        }

        public UserEntitie Login(string username, string password)
        {
            //try to login
            var allUsers = db.UserRepository.GetAllUsers();

            var user = allUsers.FirstOrDefault(u => u.Username == username && u.Password == password);

            return user;
            //if (user == null)
            //{
            //    return user;
            //}

            //throw new ArgumentNullException("Invalid username or password");
        }

        //public void Register(string username, string pass, string email, string firstName, string lastName)
        public void Register(UserEntitie userToCreate)
        {
            //var userToCreate = new UserEntitie()
            //{
            //    Username = username,
            //    Password = pass,
            //    Email = email,
            //    FirstName = firstName,
            //    LastName = lastName,
            //    //BioData ?
            //};

            db.UserRepository.Add(userToCreate);
        }

        public void UpdateBioData(UserEntitie loggedInUser)
        {
            //loggedInUser.BioData = new BioDataEntitie();
            //loggedInUser.BioData.Weight = (double)85;
            //loggedInUser.BioData.Height = (double)85;
            //loggedInUser.BioData.HipsSize = (double)85;
            //loggedInUser.BioData.WaistSize = (double)85;
            //loggedInUser.BioData.NeckSize = (double)85;
            //loggedInUser.BioData = new BioDataEntitie{ Weight = bioData.Weight,
            //Height = bioData.Height};

            db.UserRepository.Update(loggedInUser);
        }
    }
}
