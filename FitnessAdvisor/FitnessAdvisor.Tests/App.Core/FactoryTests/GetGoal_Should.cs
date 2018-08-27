using App.Core.Factory;
using App.Models.GeneralPurpose;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitnessAdvisor.Tests.App.Core.Factory
{
    [TestClass]
    public class GetGoal_Should
    {
        [TestMethod]
        public void ReturnBulkType_WhenBulkChoosen()
        {
            // Arrange
            var factory = new TransformationGoalFactory();

            // Act 
            var result = factory.GetGoal(0, 90, 15, 100);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Bulk));
        }

        [TestMethod]
        public void ReturnMaintainType_WhenMaintainChoosen()
        {
            // Arrange
            var factory = new TransformationGoalFactory();

            // Act 
            var result = factory.GetGoal(1, 90, 15, 100);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Maintain));
        }

        [TestMethod]
        public void ReturnNull_WhenInvalidChoice()
        {
            // Arrange
            var factory = new TransformationGoalFactory();

            // Act 
            var result = factory.GetGoal(5, 80, 22, 110);

            // Assert
            Assert.IsNull(result);
        }
    }
}
