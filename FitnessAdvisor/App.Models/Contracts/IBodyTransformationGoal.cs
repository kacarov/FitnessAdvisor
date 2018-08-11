using App.Models.Supplements;
using App.Models.Training;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.Contracts
{
    public interface IBodyTransformationGoal // implement abstract GP class? 
    {
        // target kg, target body fat, enddate? , daily calories goal?
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        double MinWeightTarget { get; set; }
        double MaxWeightTarget { get; set; }
        double MinFatPercentTarget { get; set; }
        double MaxFatPercentTarget { get; set; }
        TrainingType TrainingType { get; }
        void AddSupplement(Supplement supplement);
        IMealPlan MealPlan { get;  }
        List<Supplement> Supplements { get; }

    }
}
