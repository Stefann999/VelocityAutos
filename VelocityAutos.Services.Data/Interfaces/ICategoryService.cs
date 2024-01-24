using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityAutos.Web.ViewModels.SelectViewModels;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CarSelectCategoryFormModel>> AllCategoriesAsync();
    }
}
