using App.Models.Contracts;
using System;

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
                this.username = value ?? throw new ArgumentNullException("Argument cannot be null");
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
                this.bioData = value ?? throw new ArgumentNullException("Bio data cannot be null");
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
                goal = value ?? throw new ArgumentException("Goal cannot be null.");
            }
        }
    }
}
