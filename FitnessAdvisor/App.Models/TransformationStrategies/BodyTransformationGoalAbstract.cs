using App.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.TransformationStrategies
{
    public abstract class BodyTransformationGoalAbstract : IBodyTransformationGoal
    {
        private double minWeightTarget;
        private double maxWeightTarget;
        private double minFatPercentTarget;
        private double maxFatPercentTarget;
        private ITrainingType trainingType;
        private IList<ISupplement> supplements;
        private IMealPlan mealPlan;

        protected BodyTransformationGoalAbstract(int caloricNeeds, double minWeightTarget, double maxWeightTarget, double minFatPrecentTarget, double maxFatPercentTarget)
        {
            this.MinWeightTarget = minWeightTarget;
            this.MaxWeightTarget = maxWeightTarget;
            this.MinFatPercentTarget = minFatPrecentTarget;
            this.MaxFatPercentTarget = maxFatPercentTarget;
            this.StartDate = DateTime.Now;
            this.EndDate = StartDate.AddDays(30);
            this.supplements = new List<ISupplement>();
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public double MinWeightTarget
        {
            get
            {
                return this.minWeightTarget;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Minimal weight cannot be negative.");
                }
                minWeightTarget = value;
            }
        }

        public double MaxWeightTarget
        {
            get
            {
                return this.maxWeightTarget;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Maximal weight cannot be negative.");
                }
                maxWeightTarget = value;
            }
        }

        public double MinFatPercentTarget
        {
            get
            {
                return this.minFatPercentTarget;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Minimal fat percent cannot be negative.");
                }
                this.minFatPercentTarget = value;
            }
        }

        public double MaxFatPercentTarget
        {
            get
            {
                return this.maxFatPercentTarget;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Maximal fat percent cannot be negative.");
                }
                maxFatPercentTarget = value;
            }
        }

        public ITrainingType TrainingType
        {
            get
            {
                return this.trainingType;
            }
            protected set
            {
                this.trainingType = value ?? throw new ArgumentNullException("Training type cannot be null");
            }
        }

        public IList<ISupplement> Supplements
        {
            get
            {
                return new List<ISupplement>(supplements);
            }
        }

        public IMealPlan MealPlan
        {
            get
            {
                return this.mealPlan;
            }
            protected set
            {
                this.mealPlan = value ?? throw new ArgumentNullException("Meal plan cannot be null.");
            }
        }

        public void AddSupplement(ISupplement supplement)
        {
            if (supplement == null)
            {
                throw new ArgumentException("Supplement cannot be null.");
            }
            this.supplements.Add(supplement);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Your personal program:\n");
            builder.AppendLine("Program start date: " + this.StartDate);
            builder.AppendLine("Program end date: " + this.EndDate + "\n");
            builder.AppendLine($"Target weight range: [ {this.MinWeightTarget} kg <<--->> {this.MaxWeightTarget} kg ]");
            builder.AppendLine($"Target body fat range:  [ {this.MinFatPercentTarget:0.00} % <<--->> {this.MaxFatPercentTarget:0.00} % ]" + "\n");
            builder.AppendLine("Your daily meal plan:");
            builder.AppendLine(this.MealPlan.ToString());

            if (this.supplements.Count > 0)
            {
                builder.AppendLine("Supplements:");
                foreach (ISupplement supplement in this.supplements)
                {
                    builder.AppendLine(supplement.ToString());
                }
            }

            builder.AppendLine(this.TrainingType.ToString());

            return builder.ToString();
        }
    }
}
