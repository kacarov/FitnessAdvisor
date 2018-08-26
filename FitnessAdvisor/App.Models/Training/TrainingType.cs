using App.Models.Contracts;
using System;
using System.Text;

namespace App.Models.Training
{
    public class TrainingType : ITrainingType
    {
        private string description;
        private string weightLiftTip;
        private string cardioTip;

        //Holds information about user's training based on his goals.
        public TrainingType(string description, string weightLiftTip, string cardioTip)
        {
            this.Description = description;
            this.WeightLiftTip = weightLiftTip;
            this.CardioTip = cardioTip;
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            private set
            {
                this.description = value ?? throw new ArgumentNullException("Description cannot be null");
            }
        }

        public string WeightLiftTip
        {
            get
            {
                return this.weightLiftTip;
            }
            private set
            {
                this.weightLiftTip = value ?? throw new ArgumentNullException("Weight lifting tip cannot be null");
            }
        }

        public string CardioTip
        {
            get
            {
                return this.cardioTip;
            }
            private set
            {
                this.cardioTip = value ?? throw new ArgumentNullException("Cardio tip cannot be null");
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("--------------------------------");
            builder.AppendLine(this.Description + ":");
            builder.AppendLine("--------------------------------");
            builder.AppendLine("\nWeight lift Tip:");
            builder.AppendLine("--------------------------------");
            builder.AppendLine(this.WeightLiftTip);
            builder.AppendLine("\nCardio tip:");
            builder.AppendLine("--------------------------------");
            builder.AppendLine(this.CardioTip);

            return builder.ToString();
        }
    }
}
