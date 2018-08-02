using App.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.TransformationStrategies
{
    public class BodyTransformationGoalAbstract : IBodyTransformationGoal
    {
        public BodyTransformationGoalAbstract(decimal minWeightTarget, decimal maxWeightTarget, decimal minFatPercentTarget, decimal maxFatPercentTarget)
        {
            this.MinWeightTarget = minWeightTarget;
            this.MaxWeightTarget = maxWeightTarget;
            this.MinFatPercentTarget = minFatPercentTarget;
            this.MaxFatPercentTarget = maxFatPercentTarget;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal MinWeightTarget { get; set; }
        public decimal MaxWeightTarget { get; set; }

        public decimal MinFatPercentTarget { get; set; }
        public decimal MaxFatPercentTarget { get; set; }

        //public TrainingType TrainingType { get; set; }

        //public List<Supplement> Supplements { get; set; }

        public virtual int Calories { get; set; }

        //public abstract int CalculateCalories();
    }
}
