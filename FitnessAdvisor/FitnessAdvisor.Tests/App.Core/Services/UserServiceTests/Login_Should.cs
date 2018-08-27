using App.Data.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAdvisor.Tests.App.Core.Services.UserServiceTests
{
    [TestClass]
    public class Login_Should
    {
        [TestMethod]
        public void ReturnCorrectUserEntitie_WhenValidUserCredentialsPassed()
        {
            // Arrange
            var dbMock = new Mock<IDbContext>();

            var userMock = new Mock<IUserEntitie>();
            userMock.SetupGet(u => u.Username).Returns("Ivan");
            userMock.SetupGet(u => u.Password).Returns("123");

            var usersCollection = new List<IUserEntitie> { userMock.Object };
            dbMock.Setup(db => db.UserRepository.GetAllUsers()).Returns(usersCollection);

            // Act 
            var result = dbMock.Object.UserRepository.GetAllUsers().FirstOrDefault(u => u.Username == "Ivan" && u.Password == "123");

            // Assert
            Assert.AreEqual(userMock.Object, result);
        }

        [TestMethod]
        public void ReturnNull_WhenInvalidUsernamePassed()
        {
            // Arrange
            var dbMock = new Mock<IDbContext>();

            var userMock = new Mock<IUserEntitie>();
            userMock.SetupGet(u => u.Username).Returns("Ivan");
            userMock.SetupGet(u => u.Password).Returns("123");

            var usersCollection = new List<IUserEntitie> { userMock.Object };
            dbMock.Setup(db => db.UserRepository.GetAllUsers()).Returns(usersCollection);

            // Act 
            var result = dbMock.Object.UserRepository.GetAllUsers().FirstOrDefault(u => u.Username == "Gosho" && u.Password == "123");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ReturnNull_WhenInvalidPasswordPassed()
        {
            // Arrange
            var dbMock = new Mock<IDbContext>();

            var userMock = new Mock<IUserEntitie>();
            userMock.SetupGet(u => u.Username).Returns("Ivan");
            userMock.SetupGet(u => u.Password).Returns("12356");

            var usersCollection = new List<IUserEntitie> { userMock.Object };
            dbMock.Setup(db => db.UserRepository.GetAllUsers()).Returns(usersCollection);

            // Act 
            var result = dbMock.Object.UserRepository.GetAllUsers().FirstOrDefault(u => u.Username == "Ivan" && u.Password == "InvalidPassword");

            // Assert
            Assert.IsNull(result);
        }
    }
}
