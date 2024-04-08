using Microsoft.AspNetCore.Mvc;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Areas.Admin.ViewModels;
using VelocityAutos.Web.Infrastructure.Extensions;

namespace VelocityAutos.Web.Areas.Admin.Controllers
{
    public class CarController : BaseAdminController
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }
        public async Task<IActionResult> Mine()
        {
            MyCarsViewModel viewModel = new MyCarsViewModel
            {
                AddedCars = await this.carService.GetOwnedCarsAsync(this.User.GetId()!),
            };

            return View(viewModel);
        }
    }
}
