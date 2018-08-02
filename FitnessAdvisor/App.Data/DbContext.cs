using App.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data
{
    public class DbContext
    {
        public DbContext()
        {
            this.UserRepository = new UserRepository();
        }

        public UserRepository UserRepository { get; set; }
    }
}
