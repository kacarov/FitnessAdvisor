using System;
using System.Collections.Generic;
using System.Text;
using App.Models.Contracts;
using App.Models.GeneralPurpose;

namespace App.Core.Factory
{
    public class TransformationGoalFactory : ITransformationGoalFactory
    {
        public IBodyTransformationGoal GetGoal(int selectedRadioGroup, double weight, double currentFatPerc, int caloriesNeed)
        {
            switch (selectedRadioGroup)
            {
                case 0:
                    return new Bulk(weight, currentFatPerc, caloriesNeed);
                    
                case 1:
                    return new Maintain(weight, currentFatPerc, caloriesNeed);

                case 2:
                    return new Cutting(weight, currentFatPerc, caloriesNeed);

            }
            return null;
        }
    }
}
