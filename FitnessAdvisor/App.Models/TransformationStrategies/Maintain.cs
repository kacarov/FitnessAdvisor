using App.Models.TransformationStrategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.GeneralPurpose
{
    public class Maintain : BodyTransformationGoalAbstract
    {
        public Maintain(double currentWeight, double currentFatPercent) : base(currentWeight - 0.5, currentWeight + 0.5, currentFatPercent - 0.5, currentFatPercent + 0.5)
        {

        }
    }
}
