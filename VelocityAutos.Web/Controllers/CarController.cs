using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Extensions;
using VelocityAutos.Web.ViewModels.Car;
using static VelocityAutos.Common.NotificationMessagesConstants;

namespace VelocityAutos.Web.Controllers
{
	[Authorize]
    public class CarController : BaseController
    {
        // NEW ACCESS TOKEN

        private readonly ICategoryService categoryService;
        private readonly IFuelTypeService fuelTypeService;
        private readonly ITransmissionTypeService transmissionTypeService;
        private readonly ICarService carService;
        private readonly IDropboxService dropboxService;
        private readonly IPostService postService;

        public CarController(ICategoryService categoryService,
            IFuelTypeService fuelTypeService,
            ITransmissionTypeService transmissionTypeService,
            ICarService carService,
            IDropboxService dropboxService,
            IPostService postService)
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

            var user = this.User;

            //try
            //{
            //    foreach (var car in allCars)
            //    {
            //        string folderPath = $"/VelocityAutos/CarImages/Car_{car.Id}";
            //        var currCarImagesUrls = await dropboxService.GetCarImages(folderPath, true);
            //        car.ImagesPaths = currCarImagesUrls;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    TempData[ErrorMessage] = "An unexpected error occured while trying to display cars' images! Please try again! If the issue continues, contact an administrator!";
            //}

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

            return View(carFormModel);
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

			ModelState.Remove(nameof(carFormModel.SellerId));
			ModelState.Remove(nameof(carFormModel.PostId));


			string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

            if (!ModelState.IsValid)
            {
                carFormModel.Categories = await this.categoryService.AllCategoriesAsync();
                carFormModel.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                carFormModel.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(carFormModel);
            }

            string targetCarId = string.Empty;

            try
            {
                string? currUserId = this.User.GetId();
                targetCarId = await this.carService.CreateAsync(carFormModel);
                await this.postService.CreateAsync(targetCarId, currUserId!, this.User.GetEmail()!);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occured while trying to add new car! Please try again later or contact administrator!";

                carFormModel.Categories = await this.categoryService.AllCategoriesAsync();
                carFormModel.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                carFormModel.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(carFormModel);
            }

            TempData[SuccessMessage] = "Car was added for sale successfully!";
            
            return this.RedirectToAction(nameof(Details), new { id = targetCarId});
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var targetCar = await this.carService.GetCarDetailsAsync(id);

                if (targetCar == null)
                {
                    TempData[ErrorMessage] = "Car does not exist or the post is no longer available!";
                    return RedirectToAction(nameof(All));
                }

                var targetPost = await this.postService.GetPostForDetailsByIdAsync(id);

                string currUserId = this.User.GetId()!;

                bool isOwner = false;
                bool isAdmin = false;

                if (currUserId != null)
                {
                    isOwner = targetPost.SellerId == currUserId!.ToUpper();
                    isAdmin = this.User.IsAdmin();
                }

                if (!targetPost.IsActive)
                {
                    if (!isOwner && !isAdmin)
                    {
                        TempData[ErrorMessage] = "Car does not exist or the post is no longer available!";
                        return RedirectToAction(nameof(All));
                    }
                }

                targetPost.Car = targetCar;

                targetCar.ImagesPaths = await this.dropboxService.GetCarImages($"/VelocityAutos/CarImages/Car_{id}", false);

                return View(targetPost);

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occured while trying to display car details! Please try again later or contact administrator!";
                return RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var targetCar = await this.carService.GetCarEditAsync(id);

            if (targetCar == null)
            {
                TempData[ErrorMessage] = "Car does not exist or the post is no longer available!";
                return RedirectToAction(nameof(All));
            }

            string? currUserId = this.User.GetId();

            bool isOwner = targetCar.SellerId == currUserId!.ToUpper();

            if (!isOwner && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You have to be the owner of the post in order to edit it!";
                return this.RedirectToAction(nameof(Details), new { id });
            }

            targetCar.Categories = await this.categoryService.AllCategoriesAsync();
            targetCar.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
            targetCar.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();
            

            return View(targetCar);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, CarFormModel carFormModel)
        {
            var targetCar = await this.carService.GetCarEditAsync(id);

            if (targetCar == null)
            {
                TempData[ErrorMessage] = "Car does not exist or the post is no longer available!";
                return RedirectToAction(nameof(All));
            }

            ModelState.Remove(nameof(carFormModel.SellerId));
            ModelState.Remove(nameof(carFormModel.PostId));

            string? currUserId = this.User.GetId();

            bool isOwner = targetCar.SellerId == currUserId!.ToUpper();

            if (!isOwner && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You have to be the owner of the post in order to edit it!";
                return this.RedirectToAction(nameof(Details), new { id });
            }

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

            if (!ModelState.IsValid)
            {
                carFormModel.Categories = await this.categoryService.AllCategoriesAsync();
                carFormModel.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                carFormModel.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(carFormModel);
            }

            try
            {
                await this.carService.UpdateAsync(carFormModel, id);
                await this.postService.UpdateAsync(targetCar.PostId);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add new car! Please try again later or contact administrator!");

                carFormModel.Categories = await this.categoryService.AllCategoriesAsync();
                carFormModel.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                carFormModel.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(carFormModel);
            }

            TempData[SuccessMessage] = "Post was updated successfully!";

            return this.RedirectToAction(nameof(Details), new { id });
        }

        public async Task<IActionResult> Owned()
        {
            string currUserId = this.User.GetId()!;

            var allCars = await this.carService.GetOwnedCarsAsync(currUserId);

            try
            {
                foreach (var car in allCars)
                {
                    string folderPath = $"/VelocityAutos/CarImages/Car_{car.Id}";
                    var currCarImagesUrls = await dropboxService.GetCarImages(folderPath, true);
                    car.ImagesPaths = currCarImagesUrls;
                }
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "An unexpected error occured while trying to display cars' images! Please try again! If the issue continues, contact an administrator!";
            }

            return View(allCars);
        }

        public async Task<IActionResult> Save(string id)
        {
            string currUserId = this.User.GetId()!;

            try
            {
                bool isSaved =  await this.carService.SaveCarAsync(id, currUserId);

                if (!isSaved)
                {
                    TempData[ErrorMessage] = "Car is already saved or is no longer available!";
                    return RedirectToAction(nameof(All));
                }
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occured while trying to save car! Please try again later or contact administrator!";
                return RedirectToAction(nameof(All));
            }

            TempData[SuccessMessage] = "Car was saved successfully!";

            return RedirectToAction(nameof(Details), new { id });
        }

        public async Task<IActionResult> Saved()
        {
            string currUserId = this.User.GetId()!;

            var allCars = await this.carService.GetSavedCarsAsync(currUserId);

            try
            {
                foreach (var car in allCars)
                {
                    string folderPath = $"/VelocityAutos/CarImages/Car_{car.Id}";
                    var currCarImagesUrls = await dropboxService.GetCarImages(folderPath, true);
                    car.ImagesPaths = currCarImagesUrls;
                }
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = "An unexpected error occured while trying to display cars' images! Please try again! If the issue continues, contact an administrator!";
            }

            return View(allCars);
        }

        public async Task<IActionResult> RemoveSave(string id)
        {
            var currUserId = this.User.GetId()!;

            try
            {
                bool isRemoved = await this.carService.RemoveFromSavedAsync(id, currUserId);

                if (!isRemoved)
                {
                    TempData[ErrorMessage] = "Car is not saved or is no longer available!";
                    return RedirectToAction(nameof(All));
                }
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occured while trying to save car! Please try again later or contact administrator!";
                return RedirectToAction(nameof(All));
            }

            TempData[SuccessMessage] = "Car was removed from saved successfully!";

            return RedirectToAction(nameof(Saved));
        }
    }
}
