using App.Models.Calculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAdvisor.Tests.App.Core.Calculator.BodyCalculatorTests
{
    [TestClass]
    public class CalculateBodyFat_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenNullUserEntitiePassed()
        {
            // Arrange
            var calculator = new BodyCalculator();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => calculator.CalculateBodyFat(null));
        }
    }
}
