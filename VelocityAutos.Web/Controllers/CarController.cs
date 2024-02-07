using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Extensions;
using VelocityAutos.Web.ViewModels.Car;

namespace VelocityAutos.Web.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IFuelTypeService fuelTypeService;
        private readonly ITransmissionTypeService transmissionTypeService;
        private readonly ICarService carService;

        public CarController(ICategoryService categoryService, IFuelTypeService fuelTypeService, ITransmissionTypeService transmissionTypeService, ICarService carService)
        {
            this.categoryService = categoryService;
            this.fuelTypeService = fuelTypeService;
            this.transmissionTypeService = transmissionTypeService;
            this.carService = carService;
         }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return this.Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            CarFormModel formModel = new CarFormModel()
            {
                Categories = await this.categoryService.AllCategoriesAsync(),
                FuelTypes = await this.fuelTypeService.AllFuelTypesAsync(),
                TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync()
            };
            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel carFormModel)
        {
            bool categoryExists = await this.categoryService
                .ExistsByIdAsync(carFormModel.CategoryId);

            bool fuelTypeExists = await this.fuelTypeService
                .ExistsByIdAsync(carFormModel.FuelTypeId);

            bool transmissionTypeExists = await this.transmissionTypeService
                .ExistsByIdAsync(carFormModel.TransmissionTypeId);

            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(carFormModel.CategoryId), "Category does not exist.");
            }

            if (!fuelTypeExists)
            {
                   ModelState.AddModelError(nameof(carFormModel.FuelTypeId), "Fuel type does not exist.");
            }

            if (!transmissionTypeExists)
            {
                ModelState.AddModelError(nameof(carFormModel.TransmissionTypeId), "Transmission type does not exist.");
            }

            if (!carFormModel.Images.Any())
            {
                ModelState.AddModelError(nameof(carFormModel.Images), "Please attach atleast one image!");
            }

            if (!ModelState.IsValid)
            {
                carFormModel.Categories = await this.categoryService.AllCategoriesAsync();
                carFormModel.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                carFormModel.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(carFormModel);
            }

            try
            {
                string? currUserId = this.User.GetId();
                await this.carService.CreateAsync(carFormModel, currUserId);
            }
            catch (Exception _)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add new car! Please try again later or contact administrator!");

                carFormModel.Categories = await this.categoryService.AllCategoriesAsync();
                carFormModel.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                carFormModel.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(carFormModel);
            }  
            
            return this.RedirectToAction("All", "Car");
        }
    }
}
