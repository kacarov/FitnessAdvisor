using App.Models.Contracts;
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

        public BodyTransformationGoalAbstract(double minWeightTarget, double maxWeightTarget, double minFatPrecentTarget, double maxFatPercentTarget)
        {
            this.MinWeightTarget = minWeightTarget;
            this.MaxWeightTarget = maxWeightTarget;
            this.MinFatPercentTarget = minFatPercentTarget;
            this.MaxFatPercentTarget = maxFatPercentTarget;

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
                if(value < 0)
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
                minFatPercentTarget = value;
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
        public TrainingType TrainingType { get; set; }

        //public List<Supplement> Supplements { get; set; }

        public virtual int Calories { get; set; }

        //public abstract int CalculateCalories();
    }
}
