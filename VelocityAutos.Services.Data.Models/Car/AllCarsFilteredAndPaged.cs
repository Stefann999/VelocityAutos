using VelocityAutos.Web.ViewModels.Car;

namespace VelocityAutos.Services.Data.Models.Car
{
    public class AllCarsFilteredAndPaged
    {
        public AllCarsFilteredAndPaged()
        {
            this.Cars = new HashSet<CarAllViewModel>();
        }

        public int TotalCarsCount { get; set; }

        public IEnumerable<CarAllViewModel> Cars { get; set; }
    }
}
