using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VelocityAutos.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
