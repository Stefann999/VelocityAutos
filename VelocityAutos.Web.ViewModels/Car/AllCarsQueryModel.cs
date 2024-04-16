using System.ComponentModel.DataAnnotations;
using VelocityAutos.Web.ViewModels.Car.Enums;
using static VelocityAutos.Common.GeneralApplicationConstants;

namespace VelocityAutos.Web.ViewModels.Car
{
    public class AllCarsQueryModel
    {
        public AllCarsQueryModel()
        {
            this.CurrentPage = DefaultPageNumber;
            this.CarsPerPage = DefaultCarsPerPage;

            this.Cars = new HashSet<CarAllViewModel>();
            this.Categories = new HashSet<string>();
            this.FuelTypes = new HashSet<string>();
            this.TransmissionTypes = new HashSet<string>();
        }

        public string? Category { get; set; }

        [Display(Name = "Fuel type")]
        public string? FuelType { get; set; }

        [Display(Name = "Transmission type")]
        public string? TransmissionType { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchTerm { get; set; }

        [Display(Name = "Sort cars by")]
        public CarSorting CarSorting { get; set; }

        public int CurrentPage { get; set; }

        public int TotalCars { get; set; }

        [Display(Name = "Cars per page")]
        public int CarsPerPage { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<string> FuelTypes { get; set; } = null!;

        public IEnumerable<string> TransmissionTypes { get; set; } = null!;

        public IEnumerable<CarAllViewModel> Cars { get; set; } = null!;
    }
}
