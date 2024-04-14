using System.Security.Claims;
using VelocityAutos.Web.Infrastructure.Extensions;
using static VelocityAutos.Common.GeneralApplicationConstants;

namespace VelocityAutos.Tests
{
    [TestFixture]
    public class ClaimsPrincipalExtensionsTests
    {
        [Test]
        public void GetIdSuccessfully()
        {
            var userId = "123";
            var claims = new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));

            var id = user.GetId();

            Assert.AreEqual(userId, id);
        }

        [Test]
        public void GetIdReturnsNull()
        {
            var user = new ClaimsPrincipal();

            var id = user.GetId();

            Assert.IsNull(id);
        }

        [Test]
        public void IsAdminReturnsTrue()
        {
            var claims = new Claim[] { new Claim(ClaimTypes.Role, AdminRoleName) };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));

            var isAdmin = user.IsAdmin();

            Assert.IsTrue(isAdmin);
        }

        [Test]
        public void IsAdminReturnsFalse()
        {
            var user = new ClaimsPrincipal();

            var isAdmin = user.IsAdmin();

            Assert.IsFalse(isAdmin);
        }

        [Test]
        public void GetEmailSuccessfully()
        {
            var email = "test@example.com";
            var claims = new Claim[] { new Claim(ClaimTypes.Email, email) };
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims));

            var userEmail = user.GetEmail();

            Assert.AreEqual(email, userEmail);
        }

        [Test]
        public void GetEmailReturnsNull()
        {
            var user = new ClaimsPrincipal();

            var userEmail = user.GetEmail();

            Assert.IsNull(userEmail);
        }
    }
}