using FitnessAdvisor.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAdvisor.Tests
{
    [TestClass]
    public class BodyTransformationGoal_Should
    {
        [TestMethod]
        public void CreateInstance_WhenValidParametersArePassed()
        {
            //Arrange and Act
            //Create BodyTransformationGoalAbstractMock with valid parameters
            BodyTransformationGoalMock bodyTransformationGoalMock = new BodyTransformationGoalMock(93, 95, 15, 16);

            //Assert

            Assert.IsNotNull(bodyTransformationGoalMock, "BodyTransformationGoalAbstract is not created.");
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvalidMinumumWeightTargetIsPassed()
        {
            Assert.ThrowsException<ArgumentException>(() => new BodyTransformationGoalMock(-1, 95, 15, 16), "Exception is not trown.");
        }
    }
}
