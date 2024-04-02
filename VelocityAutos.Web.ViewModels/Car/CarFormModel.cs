using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using VelocityAutos.Services.Mapping;
using VelocityAutos.Web.ViewModels.FuelType;
using VelocityAutos.Web.ViewModels.SelectViewModels;
using static VelocityAutos.Common.EntityValidationConstants.Car;
using static VelocityAutos.Common.ErrorConstants;

namespace VelocityAutos.Web.ViewModels.Car
{
    using AutoMapper;
    using Data.Models;

    public class CarFormModel : IMapFrom<Car>
    {
        public CarFormModel()
        {
            this.FuelTypes = new HashSet<CarSelectFuelTypeFormModel>();
            this.TransmissionTypes = new HashSet<CarSelectTransmissionFormModel>();
            this.Categories = new HashSet<CarSelectCategoryFormModel>();
            this.Images = new HashSet<IFormFile>();
        }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(CarMakeMaxLength, MinimumLength = CarMakeMinLength)]
        public string Make { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string Model { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(typeof(decimal), CarPriceMinValue, CarPriceMaxValue)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(CarMonthMinValue, CarMonthMaxValue)]
        [Display(Name = "Month of production")]
        public int Month { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(CarYearMinValue, CarYearMaxValue)]
        [Display(Name = "Year of production")]
        public int Year { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(CarMileageMinValue, CarMileageMaxValue)]
        [Display(Name = "Mileage in kilometers")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(CarHorsePowerMinValue, CarHorsePowerMaxValue)]
        public int HorsePower { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(CarFuelConsumptionMinValue, CarFuelConsumptionMaxValue)]
        public double FuelConsumption { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Color { get; set; } = null!;

        public string? Description { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(CarLocationCityMaxLength, MinimumLength = CarLocationCityMinLength)]
        public string LocationCity { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(CarLocationCountryMaxLength, MinimumLength = CarLocationCountryMinLength)]
        public string LocationCountry { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Transmission type")]
        public int TransmissionTypeId { get; set; }

        public IEnumerable<CarSelectTransmissionFormModel> TransmissionTypes { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Fuel type")]
        public int FuelTypeId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public IEnumerable<CarSelectFuelTypeFormModel> FuelTypes { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public string PostId { get; set; }

        public string SellerId { get; set; }

        public IEnumerable<CarSelectCategoryFormModel> Categories { get; set; }

        [Display(Name = "ImagesPaths of the car")]
        public IEnumerable<IFormFile> Images { get; set; }

    }
}
