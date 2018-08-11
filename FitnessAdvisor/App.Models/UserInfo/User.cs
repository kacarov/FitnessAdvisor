using App.Models.Contracts;
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
       
        private BioData bioData;
        private IBodyTransformationGoal goal;
        public User(string username, BioData bioData)
        {
            Username = username;
            BioData = bioData;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Argument cannot be null");
                }
                this.username = value;
            }
        }
        public BioData BioData
        {
            get
            {
                return this.bioData;
            }
            set
            {
                this.bioData = value;
            }
        }
        public IBodyTransformationGoal Goal
        {
            get
            {
                return this.goal;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentException("Goal cannot be null.");
                }
                goal = value;
            }
        }
    }
}
