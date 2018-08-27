using App.Models.Contracts;
using FitnessAdvisor.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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

        [TestMethod]
        public void ThrowArgumentException_WhenInvalidMaximumWeightTargetIsPassed()
        {
            Assert.ThrowsException<ArgumentException>(() => new BodyTransformationGoalMock(93, -1, 15, 16), "Exception is not trown.");
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvalidMinimumBodyfatTargetIsPassed()
        {
            Assert.ThrowsException<ArgumentException>(() => new BodyTransformationGoalMock(93, 95, -1, 16), "Exception is not trown.");
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvalidMaximumBodyfatTargetIsPassed()
        {
            Assert.ThrowsException<ArgumentException>(() => new BodyTransformationGoalMock(93, 95, 15, -1), "Exception is not trown.");
        }

        [TestMethod]
        public void AddSupplementToSupplementList_WhenValidSupplementIsPassed()
        {
            //Arrange 

            var bodyTransformationGoalMock = new BodyTransformationGoalMock(93, 95, 15, 17);
            var supplement = new Mock<ISupplement>();
            supplement.SetupGet(x => x.Name).Returns("Whey Gold Standart");

            //Act

            bodyTransformationGoalMock.AddSupplement(supplement.Object);

            //Assert

            Assert.AreEqual("Whey Gold Standart", bodyTransformationGoalMock.Supplements[0].Name);
        }

    }
}
