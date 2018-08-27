using App.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Factory
{
   public interface ITransformationGoalFactory
    {
        IBodyTransformationGoal GetGoal(int selectedRadioGroup, double weight, double currentFatPerc, int caloriesNeed);
    }
}
