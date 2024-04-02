using System.Security.Claims;
using static VelocityAutos.Common.GeneralApplicationConstants;

namespace VelocityAutos.Web.Infrastructure.Extensions
{

    public static class ClaimsPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName);
        }

        public static string GetEmail(this ClaimsPrincipal user)
        {
			return user.FindFirstValue(ClaimTypes.Email);
		}
    }
}
