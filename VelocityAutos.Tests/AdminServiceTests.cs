using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Services.Data;
using VelocityAutos.Web.Infrastructure.Common;


namespace VelocityAutos.Tests
{
    [TestFixture]
    public class AdminServiceTests
    {
        private AdminService adminService;
        private Mock<IUserService> userServiceMock;
        private Mock<UserManager<ApplicationUser>> userManagerMock;
        private Mock<IRepository> repositoryMock;

        [SetUp]
        public void Setup()
        {
            userServiceMock = new Mock<IUserService>();
            userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            repositoryMock = new Mock<IRepository>();

            adminService = new AdminService(userServiceMock.Object, repositoryMock.Object, userManagerMock.Object);
        }

        [Test]
        public async Task AddAdminSuccessfully()
        {
            // Arrange
            var userId = "DF23030B-B89F-48C3-D18B-08DC57075207".ToLower();
            var user = new ApplicationUser { Id = Guid.Parse(userId) };
            userServiceMock.Setup(u => u.GetUserByIdAsync(userId)).ReturnsAsync(user);

            // Act
            var result = await adminService.AddAdminAsync(userId);

            // Assert
            Assert.AreEqual(userId, result);
            userManagerMock.Verify(u => u.AddToRoleAsync(user, "Administrator"), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task RemoveAdminSuccessfully()
        {
            // Arrange
            var userId = "DF23030B-B89F-48C3-D18B-08DC57075207".ToLower();
            var user = new ApplicationUser { Id = Guid.Parse(userId) };
            userServiceMock.Setup(u => u.GetUserByIdAsync(userId)).ReturnsAsync(user);

            // Act
            var result = await adminService.RemoveAdminAsync(userId);

            // Assert
            Assert.AreEqual(userId, result);
            userManagerMock.Verify(u => u.RemoveFromRoleAsync(user, "Administrator"), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}