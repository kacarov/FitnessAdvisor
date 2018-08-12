using App.Models.Contracts;
using System;

namespace App.Models.UserInfo
{
    public class User : IUser
    {
        private string username;
        /* /// <summary>
         /// What information do we need ? password? email?
         /// </summary>
         /// */

        private IBioData bioData;
        private IBodyTransformationGoal goal;

        public User(string username, IBioData bioData)
        {
            this.Username = username;
            this.BioData = bioData;
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

        public IBioData BioData
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
            private set
            {
                goal = value ?? throw new ArgumentException("Goal cannot be null.");
            }
        }

        //review this
        public void SetTransformationGoal(IBodyTransformationGoal goal)
        {
            this.Goal = goal;
        }
    }
}
