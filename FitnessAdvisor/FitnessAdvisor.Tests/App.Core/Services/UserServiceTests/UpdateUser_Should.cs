using App.Data.Contracts;
using FitnessAdvisor.Tests.App.Core.Services.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace FitnessAdvisor.Tests.App.Core.Services.UserServiceTests
{
    [TestClass]
    public class UpdateUser_Should
    {
        [TestMethod]
        public void UpdateUserEntitieInDatabase_WhenValidUserEntitiePassed()
        {
            // Arrange
            var userRepositoryMock = new UserRepositoryMock();

            var userMock = new Mock<IUserEntitie>();
            userMock.SetupGet(u => u.Username).Returns("Ivan");
            userMock.SetupGet(u => u.Password).Returns("12356");

            // Act 
            userRepositoryMock.Update(userMock.Object);

            // Assert
            Assert.AreEqual(userMock.Object, userRepositoryMock.FakeLiteDb.Single());
        }
    }
}
