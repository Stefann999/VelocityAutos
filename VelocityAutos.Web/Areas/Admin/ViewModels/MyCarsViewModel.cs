using VelocityAutos.Web.ViewModels.Car;

namespace VelocityAutos.Web.Areas.Admin.ViewModels
{
    public class MyCarsViewModel
    {
        public MyCarsViewModel()
        {
            this.AddedCars = new HashSet<CarAllViewModel>();
        }

        public IEnumerable<CarAllViewModel> AddedCars { get; set; } = null!;
    }
}
