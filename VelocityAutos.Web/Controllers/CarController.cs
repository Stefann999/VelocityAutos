using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Extensions;
using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Web.ViewModels.Post;
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

            postFormModel.SellerId = this.User.GetId()!;

            ModelState.Remove(nameof(postFormModel.SellerId));
            ModelState.Remove(nameof(postFormModel.Id));

            string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

            if (!ModelState.IsValid)
            {
                postFormModel.Car.Categories = await this.categoryService.AllCategoriesAsync();
                postFormModel.Car.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                postFormModel.Car.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(postFormModel);
            }

            string targetCarId = string.Empty;

            try
            {
                string? currUserId = this.User.GetId();
                targetCarId = await this.carService.CreateAsync(postFormModel.Car);
                var targetCar = await this.carService.GetCarEntityAsync(targetCarId);
                await this.postService.CreateAsync(postFormModel, targetCar, currUserId!);
                targetCarId = targetCar.Id.ToString();
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add new car! Please try again later or contact administrator!");

                postFormModel.Car.Categories = await this.categoryService.AllCategoriesAsync();
                postFormModel.Car.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                postFormModel.Car.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(postFormModel);
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

                targetPost.Car = targetCar;

                return View(targetPost);

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occured while trying to add new targetCar! Please try again later or contact administrator!";
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

            var targetPost = await this.postService.GetPostForEditByIdAsync(id);

            bool isOwner = targetPost.SellerId == currUserId.ToUpper();

            if (!isOwner && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You have to be the owner of the post in order to edit it!";
                return this.RedirectToAction(nameof(Details), new { id });
            }

            targetPost.Car = targetCar;

            targetPost.Car.Categories = await this.categoryService.AllCategoriesAsync();
            targetPost.Car.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
            targetPost.Car.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();
            

            return View(targetPost);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PostFormModel postFormModel)
        {
            var targetCar = await this.carService.GetCarEditAsync(id);

            if (targetCar == null)
            {
                TempData[ErrorMessage] = "Car does not exist or the post is no longer available!";
                return RedirectToAction(nameof(All));
            }

            ModelState.Remove(nameof(postFormModel.SellerId));

            string? currUserId = this.User.GetId();

            var targetPost = await this.postService.GetPostForEditByIdAsync(id);

            ModelState.Remove(nameof(postFormModel.Id));

            bool isOwner = targetPost.SellerId == currUserId.ToUpper();

            if (!isOwner && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You have to be the owner of the post in order to edit it!";
                return this.RedirectToAction(nameof(Details), new { id });
            }

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

            if (!ModelState.IsValid)
            {
                postFormModel.Car.Categories = await this.categoryService.AllCategoriesAsync();
                postFormModel.Car.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                postFormModel.Car.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(postFormModel);
            }

            try
            {
                await this.carService.UpdateAsync(postFormModel.Car, id);
                await this.postService.UpdateAsync(postFormModel, targetPost.Id);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add new car! Please try again later or contact administrator!");

                postFormModel.Car.Categories = await this.categoryService.AllCategoriesAsync();
                postFormModel.Car.FuelTypes = await this.fuelTypeService.AllFuelTypesAsync();
                postFormModel.Car.TransmissionTypes = await this.transmissionTypeService.AllTransmissionTypesAsync();

                return this.View(postFormModel);
            }

            TempData[SuccessMessage] = "Post was updated successfully!";

            return this.RedirectToAction(nameof(Details), new { id });
        }
    }
}
