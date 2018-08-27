using App.Data.Contracts;
using FitnessAdvisor.Tests.App.Core.Services.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace FitnessAdvisor.Tests.App.Core.Services.UserServiceTests
{
    [TestClass]
    public class Register_Should
    {
        [TestMethod]
        public void AddUserEntitieToDatabase_WhenValidUserEntitiePassed()
        {
            // Arrange
            var userRepositoryMock = new UserRepositoryMock();

            var userMock = new Mock<IUserEntitie>();
            userMock.SetupGet(u => u.Username).Returns("Ivan");
            userMock.SetupGet(u => u.Password).Returns("12356");

            // Act 
            userRepositoryMock.Add(userMock.Object);

            // Assert
            Assert.AreEqual(userRepositoryMock.FakeLiteDb.Count(), 1);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenNullUserEntitiePassed()
        {
            // Arrange
            var userRepositoryMock = new UserRepositoryMock();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => userRepositoryMock.Add(null));
        }
    }
}
