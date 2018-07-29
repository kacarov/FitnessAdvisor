using App.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.UserInfo
{
   public class User
    {
        private string username;
        /* /// <summary>
         /// What information do we need ? password? email?
         /// </summary>
         /// */
        private int age;
        private GenderType gender;
       private BioData measurements;
        public User(string username, int age, GenderType gender, BioData measurements)
        {
            Username = username;
            Age = age;
            Gender = gender;
            Measurements = measurements;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Argument cannot be null");
                }
                this.username = value;
            }
         }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if(value < 16 || value > 120)
                {
                    throw new ArgumentException("Age must be between 16 and 120");
                }
                this.age = value;
            }
        }
        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }
        public BioData Measurements
        {
            get
            {
                return this.measurements;
            }
            set
            {
                this.measurements = value;
            }
        }
    }
}
