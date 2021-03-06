﻿using App.Core.Contracts;
using App.Data.Contracts;
using System;
using System.Linq;

namespace App.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContext db;

        public UserService(IDbContext db)
        {
            this.db = db;
        }

        public IUserEntitie Login(string username, string password)
        {
            //try to login
            var allUsers = db.UserRepository.GetAllUsers();

            var user = allUsers.FirstOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }

        public void Register(IUserEntitie userToCreate)
        {
            if (userToCreate == null)
            {
                throw new ArgumentNullException("User cannot be null!");
            }

            db.UserRepository.Add(userToCreate);
        }

        public void UpdateUser(IUserEntitie loggedInUser)
        {
            if (loggedInUser == null)
            {
                throw new ArgumentNullException("User cannot be null!");
            }

            db.UserRepository.Update(loggedInUser);
        }
    }
}
