using App.Models.Calculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FitnessAdvisor.Tests.App.Core.Calculator.BodyCalculatorTests
{

    [TestClass]
    public class CalculateCalories_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenNullUserEntitiePassed()
        {
            // Arrange
            var calculator = new BodyCalculator();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => calculator.CalculateCalories(null));
        }
    }

}
