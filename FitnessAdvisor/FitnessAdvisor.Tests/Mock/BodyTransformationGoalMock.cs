using App.Models.TransformationStrategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAdvisor.Tests.Mock
{
    class BodyTransformationGoalMock : BodyTransformationGoalAbstract
    {
        public BodyTransformationGoalMock(double minWeightTarget, double maxWeightTarget, double minFatPrecentTarget, double maxFatPercentTarget) : base(minWeightTarget, maxWeightTarget, minFatPrecentTarget, maxFatPercentTarget)
        {
        }
    }
}
