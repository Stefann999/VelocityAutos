using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelocityAutos.Services.Data;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Extensions;
using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Web.ViewModels.Post;
using static VelocityAutos.Common.GeneralApplicationConstants;
using static VelocityAutos.Common.NotificationMessagesConstants;

namespace VelocityAutos.Web.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        // NEW ACCESS TOKEN

        private readonly ICategoryService categoryService;
        private readonly IFuelTypeService fuelTypeService;
        private readonly ITransmissionTypeService transmissionTypeService;
        private readonly ICarService carService;
        private readonly IDropboxService dropboxService;
        private readonly IPostService postService;

        public CarController(ICategoryService categoryService, IFuelTypeService fuelTypeService, ITransmissionTypeService transmissionTypeService, ICarService carService, IDropboxService dropboxService, IPostService postService)
        {
            this.categoryService = categoryService;
            this.fuelTypeService = fuelTypeService;
            this.transmissionTypeService = transmissionTypeService;
            this.carService = carService;
            this.dropboxService = dropboxService;
            this.postService = postService;
         }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var allCars = await this.carService.GetAllCarsAsync();

            try

            {
                foreach (var car in allCars)
                {
                    string folderPath = $"/VelocityAutos/CarImages/Car_{car.Id}";
                    var currCarImagesUrls = await dropboxService.GetCarImages(folderPath);
                    car.ImagesPaths = currCarImagesUrls;
                }
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "An unexpected error occured while trying to display cars' images! Please try again! If the issue continues, contact an administrator!";
            }

            return View(allCars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            CarFormModel carFormModel = new CarFormModel()
            {
                Categories = await this.categoryService.AllCategoriesAsync(),
                FuelTypes = await this.fuelTypeService.AllFuelTypesAsync(),
                TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync()
            };

            PostFormModel postFormModel = new PostFormModel()
            {
                Car = carFormModel,
            };

            return View(postFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel postFormModel)
        {
            bool categoryExists = await this.categoryService
                .ExistsByIdAsync(postFormModel.Car.CategoryId);

            bool fuelTypeExists = await this.fuelTypeService
                .ExistsByIdAsync(postFormModel.Car.FuelTypeId);

            bool transmissionTypeExists = await this.transmissionTypeService
                .ExistsByIdAsync(postFormModel.Car.TransmissionTypeId);

            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(postFormModel.Car.CategoryId), "Category does not exist.");
            }

            if (!fuelTypeExists)
            {
                   ModelState.AddModelError(nameof(postFormModel.Car.FuelTypeId), "Fuel type does not exist.");
            }

            if (!transmissionTypeExists)
            {
                ModelState.AddModelError(nameof(postFormModel.Car.TransmissionTypeId), "Transmission type does not exist.");
            }

            if (!postFormModel.Car.Images.Any())
            {
                ModelState.AddModelError(nameof(postFormModel.Car.Images), "Please attach atleast one image!");
            }

            if (!ModelState.IsValid)
            {
                postFormModel.Car.Categories = await this.categoryService.AllCategoriesAsync();
                postFormModel.Car.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                postFormModel.Car.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(postFormModel);
            }

            try
            {
                string? currUserId = this.User.GetId();
                await this.carService.CreateAsync(postFormModel.Car);
                var targetCar = await this.carService.GetCar(postFormModel.Car, currUserId!);
                await this.postService.CreateAsync(postFormModel, targetCar, currUserId!);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add new car! Please try again later or contact administrator!");

                postFormModel.Car.Categories = await this.categoryService.AllCategoriesAsync();
                postFormModel.Car.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                postFormModel.Car.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(postFormModel);
            }  
            
            return this.RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return this.View();
        }

    }
}
