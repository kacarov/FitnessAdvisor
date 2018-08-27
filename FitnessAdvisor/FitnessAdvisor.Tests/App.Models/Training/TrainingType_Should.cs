using App.Models.Training;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FitnessAdvisor.Tests
{
    [TestClass]
    public class TrainingType_Should
    {
        [TestMethod]
        public void CreateNewInstance_WhenValidParameterArePassed()
        {
            //Arrange and Act

            var validDescription = "validDescription";
            var validWeightLiftTip = "validWeightLiftTip";
            var validCardioTip = "validCardioTip";

            TrainingType trainingType = new TrainingType(validDescription, validWeightLiftTip, validCardioTip);
        
            //Assert

            Assert.IsNotNull(trainingType,"Training type is not created.");
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenNullDescriptionIsPassed()
        {
            Assert.ThrowsException<ArgumentNullException>(()=> new TrainingType(null, "validWeightTip", "validCardioTip"), "Exception is not thrown");
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenNullWeightLiftTipIsPassed()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new TrainingType("validDescription", null, "validCardioTip"), "Exception is not thrown");
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenNullCardioTipIsPassed()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new TrainingType("validDescription", "validWeightTip", null), "Exception is not thrown");
        }
    }
}
