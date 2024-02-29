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

            this.Categories = new HashSet<string>();
            this.Cars = new HashSet<CarAllViewModel>();
        }

        //TODO Add more search options (e.g. by year, by brand, by model,from - to horsepower, etc.)

        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchTerm { get; set; }

        [Display(Name = "Sort by")]
        public CarSorting CarSorting { get; set; }

        public int CurrentPage { get; set; }

        public int TotalCars { get; set; }

        public int CarsPerPage { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<CarAllViewModel> Cars { get; set; } = null!;
    }
}
