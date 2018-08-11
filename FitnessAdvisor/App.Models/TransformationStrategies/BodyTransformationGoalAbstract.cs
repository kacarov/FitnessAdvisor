using App.Models.Contracts;
using App.Models.Supplements;
using App.Models.Training;
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
        private TrainingType trainingType;
        private List<Supplement> supplements;
        private IMealPlan mealPlan;

        public BodyTransformationGoalAbstract(int caloricNeeds, double minWeightTarget, double maxWeightTarget, double minFatPrecentTarget, double maxFatPercentTarget)
        {
            this.MinWeightTarget = minWeightTarget;
            this.MaxWeightTarget = maxWeightTarget;
            this.MinFatPercentTarget = minFatPrecentTarget;
            this.MaxFatPercentTarget = maxFatPercentTarget;
            StartDate = DateTime.Now;
            EndDate = StartDate.AddDays(30);
            supplements = new List<Supplement>();
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double MinWeightTarget
        {
            get
            {
                return this.minWeightTarget;
            }
            set
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
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Maimal weight cannot be negative.");
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
            set
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
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Maximal fat percent cannot be negative.");
                }
                maxFatPercentTarget = value;
            }
        }
        public TrainingType TrainingType
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
        public List<Supplement> Supplements
        {
            get
            {
                return new List<Supplement>(supplements);
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
        public void AddSupplement(Supplement supplement)
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
            builder.AppendLine("Personal program:");
            builder.AppendLine("Program start date: " + StartDate);
            builder.AppendLine("Program end date: " + EndDate + "\n");
            builder.AppendLine("Weight range: " + MinWeightTarget + " - " + MaxWeightTarget);
            builder.AppendLine("Body fat range: " + MinFatPercentTarget + " - " + MaxFatPercentTarget + "\n");
            builder.AppendLine(mealPlan.ToString());
            if (supplements.Count > 0)
            {
                builder.AppendLine("Supplements:");
                foreach (Supplement supplement in supplements)
                {
                    builder.AppendLine(supplement.ToString());
                }
            }
            builder.AppendLine(trainingType.ToString());
            return builder.ToString();
        }
    }
}
