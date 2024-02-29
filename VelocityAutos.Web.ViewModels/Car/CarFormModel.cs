using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

using VelocityAutos.Web.ViewModels.FuelType;
using VelocityAutos.Web.ViewModels.SelectViewModels;
using static VelocityAutos.Common.EntityValidationConstants.Car;

namespace VelocityAutos.Web.ViewModels.Car
{
    public class CarFormModel
    {
        public CarFormModel()
        {
            this.FuelTypes = new HashSet<CarSelectFuelTypeFormModel>();
            this.TransmissionTypes = new HashSet<CarSelectTransmissionFormModel>();
            this.Categories = new HashSet<CarSelectCategoryFormModel>();
            this.Images = new HashSet<IFormFile>();
        }

        [StringLength(CarMakeMaxLength, MinimumLength = CarMakeMinLength)]
        public string Make { get; set; } = null!;

        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string Model { get; set; } = null!;

        [Range(typeof(decimal), CarPriceMinValue, CarPriceMaxValue)]
        public decimal Price { get; set; }

        [Range(CarMonthMinValue, CarMonthMaxValue)]
        [Display(Name = "Month of production")]
        public int Month { get; set; }

        [Range(CarYearMinValue, CarYearMaxValue)]
        [Display(Name = "Year of production")]
        public int Year { get; set; }

        [Range(CarMileageMinValue, CarMileageMaxValue)]
        [Display(Name = "Mileage in kilometers")]
        public int Mileage { get; set; }

        [Range(CarHorsePowerMinValue, CarHorsePowerMaxValue)]
        public int HorsePower { get; set; }

        [Range(CarFuelConsumptionMinValue, CarFuelConsumptionMaxValue)]
        public double FuelConsumption { get; set; }

        public string Color { get; set; } = null!;

        public string? Description { get; set; }

        [StringLength(CarLocationCityMaxLength, MinimumLength = CarLocationCityMinLength)]
        public string LocationCity { get; set; }

        [StringLength(CarLocationCountryMaxLength, MinimumLength = CarLocationCountryMinLength)]
        public string LocationCountry { get; set; }

        [Display(Name = "Transmission type")]
        public int TransmissionTypeId { get; set; }

        public IEnumerable<CarSelectTransmissionFormModel> TransmissionTypes { get; set; }

        [Display(Name = "Fuel type")]
        public int FuelTypeId { get; set; }

        public IEnumerable<CarSelectFuelTypeFormModel> FuelTypes { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CarSelectCategoryFormModel> Categories { get; set; }

        [Display(Name = "ImagesPaths of the car")]
        public IEnumerable<IFormFile> Images { get; set;}
    }
}
