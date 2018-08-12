using App.Models.Supplements;
using App.Models.Training;
using System;
using System.Collections.Generic;

namespace App.Models.Contracts
{
    public interface IBodyTransformationGoal
    {
        DateTime StartDate { get; }

        DateTime EndDate { get; }

        double MinWeightTarget { get; }

        double MaxWeightTarget { get; }

        double MinFatPercentTarget { get; }

        double MaxFatPercentTarget { get; }

        ITrainingType TrainingType { get; }

        IMealPlan MealPlan { get; }

        IList<ISupplement> Supplements { get; }

        void AddSupplement(ISupplement supplement);
    }
}
