using App.Models.TransformationStrategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.GeneralPurpose
{
    public class Cutting: BodyTransformationGoalAbstract
    {
        public Cutting(double currentWeight, double currentFatPercent) : base(currentWeight - 5, currentWeight + 3, currentFatPercent -3, currentFatPercent)
        {

        }
    }
}
