using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VelocityAutos.Common.EntityValidationConstants.Car;

namespace VelocityAutos.Data.Models
{
    public class Car
    {
        public Car()
        {
            this.Id = new Guid();
            this.Images = new HashSet<Image>();
            this.UsersFavourite = new HashSet<ApplicationUser>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(CarMakeMinLength)]
        [MaxLength(CarMakeMaxLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MinLength(CarModelMinLength)]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        [Range(CarPriceMinValue, CarPriceMaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Range(CarMonthMinValue, CarMonthMaxValue)]
        public int Month { get; set; }

        [Required]
        [Range(CarYearMinValue, CarYearMaxValue)]
        public int Year { get; set; }

        [Required]
        [Range(CarMileageMinValue, CarMileageMaxValue)]
        public int Mileage { get; set; }

        [Required]
        [Range(CarHorsePowerMinValue, CarHorsePowerMaxValue)]
        public int HorsePower { get; set; }

        public int FuelTypeId { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        [Range(CarFuelConsumptionMinValue, CarFuelConsumptionMaxValue)]
        public double FuelConsumption { get; set; }

        public int TransmissionTypeId { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        public string Color { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        [MinLength(CarLocationCityMinLength)]
        [MaxLength(CarLocationCityMaxLength)]
        public string LocationCity { get; set; }

        [Required]
        [MinLength(CarLocationCountryMinLength)]
        [MaxLength(CarLocationCountryMaxLength)]
        public string LocationCountry { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Guid OwnerId { get; set; }

        public ApplicationUser Owner { get; set; } = null!;

        public bool isSold { get; set; }

        public virtual ICollection<Image> Images { get; set; } = null!;

        public virtual ICollection<ApplicationUser> UsersFavourite { get; set; } = null!;
    }
}
