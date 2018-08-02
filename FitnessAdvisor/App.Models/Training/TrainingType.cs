using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.Training
{
    public class TrainingType
    {
        private string description;
        private string weightLiftTip;
        private string cardioTip;

        public TrainingType(string weightLiftTip, string cardioTip)
        {
            
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Description cannot be null");
                }
                this.description = value;
            }
        }
        public string WeightLiftTip
        {
            get
            {
                return this.weightLiftTip;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The tip for  cannot be null");
                }
                this.weightLiftTip = value;
            }
        }

    }
}
