using App.Models.TransformationStrategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.GeneralPurpose
{
    public class Bulk : BodyTransformationGoalAbstract
    {
        public Bulk(double currentWeight, double currentFatPercent) : base(currentWeight+3, currentWeight+5, currentFatPercent, currentFatPercent + 2)
        {
            //  base.StartDate = DateTime.Now();
            // base.EndDate = base.StartDate + 



           // base.TrainingType = new TrainingBulk(weightTip,cardioTip);
        }
    }
}
