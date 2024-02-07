using Microsoft.EntityFrameworkCore;

using VelocityAutos.Data;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.ViewModels.SelectViewModels;

namespace VelocityAutos.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly VelocityAutosDbContext dbContext;
        public CategoryService(VelocityAutosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CarSelectCategoryFormModel>> AllCategoriesAsync()
        {
            IEnumerable<CarSelectCategoryFormModel> categories = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new CarSelectCategoryFormModel
                {
                    Id = c.Id,
                    Name = c.CategoryName
                })
                .ToArrayAsync();

            return categories;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Categories
                .AnyAsync(c => c.Id == id);

            return result;
        }
    }
}
