using App.Models.Contracts;
using System;
using System.Text;
//LOOK FOR VALIDATIONS
namespace App.Models.Training
{
    public class TrainingType : ITrainingType
    {
        private string description;
        private string weightLiftTip;
        private string cardioTip;

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

            builder.AppendLine(Description + ":");
            builder.AppendLine("Weight lift Tip:\n" + this.WeightLiftTip);
            builder.AppendLine("Cardio tip:\n" + this.CardioTip);

            return builder.ToString();
        }
    }
}
