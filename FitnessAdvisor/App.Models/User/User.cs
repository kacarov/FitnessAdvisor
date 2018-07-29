using App.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.User
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public BioData BioData { get; set; }

        public IGeneralPurpose GeneralPurpose { get; set; }
    }
}
