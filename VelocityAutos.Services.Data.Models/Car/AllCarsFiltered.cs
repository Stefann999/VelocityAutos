using VelocityAutos.Web.ViewModels.Car;

namespace VelocityAutos.Services.Data.Models.Car
{
    public class AllCarsFiltered
    {
        public AllCarsFiltered()
        {
            this.Cars = new HashSet<CarAllViewModel>();
        }

        public int TotalCarsCnt { get; set; }

        public IEnumerable<CarAllViewModel> Cars{ get; set; }
    }
}
