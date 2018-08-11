using App.Models.Supplements;
using App.Models.Training;
using System;
using System.Collections.Generic;

namespace App.Models.Contracts
{
    public interface IBodyTransformationGoal
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        double MinWeightTarget { get; set; }
        double MaxWeightTarget { get; set; }
        double MinFatPercentTarget { get; set; }
        double MaxFatPercentTarget { get; set; }
        TrainingType TrainingType { get; }
        void AddSupplement(Supplement supplement);
        IMealPlan MealPlan { get; }
        List<Supplement> Supplements { get; }

    }
}
