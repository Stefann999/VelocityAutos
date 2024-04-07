using VelocityAutos.Web.ViewModels.SelectViewModels;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CarSelectCategoryFormModel>> AllCategoriesAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
