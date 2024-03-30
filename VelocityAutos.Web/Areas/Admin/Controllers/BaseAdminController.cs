using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VelocityAutos.Common.GeneralApplicationConstants;

namespace VelocityAutos.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
      
    }
}
