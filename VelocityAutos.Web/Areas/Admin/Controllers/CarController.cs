using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Areas.Admin.ViewModels;
using VelocityAutos.Web.Infrastructure.Extensions;
using static VelocityAutos.Common.NotificationMessagesConstants;

namespace VelocityAutos.Web.Areas.Admin.Controllers
{
    public class CarController : BaseAdminController
    {
        private readonly ICarService carService;
        private readonly IDropboxService dropboxService;

        public CarController(ICarService carService, IDropboxService dropboxService)
        {
            this.carService = carService;
            this.dropboxService = dropboxService;
        }
        public async Task<IActionResult> Mine()
        {
            MyCarsViewModel viewModel = new MyCarsViewModel
            {
                AddedCars = await this.carService.GetOwnedCarsAsync(this.User.GetId()!),
            };

            return View(viewModel);
        }

       [Route("/Car/Dashboard")]
       public async Task<IActionResult> CarsDashboard()
       {
           var cars = await this.carService.AdminGetAllCarsAsync();

            try
            {
                foreach (var car in cars)
                {
                    string folderPath = $"/VelocityAutos/CarImages/Car_{car.CarId}";
                    var currCarImagesUrls = await dropboxService.GetCarImages(folderPath, true);
                    car.ImagesPaths = currCarImagesUrls;
                }
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "An unexpected error occured while trying to display cars' images! Please try again! If the issue continues, contact an administrator!";
            }

            return this.View(cars);
       }
    }
}
