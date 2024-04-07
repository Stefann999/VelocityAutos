using Microsoft.EntityFrameworkCore;

using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;
using VelocityAutos.Web.ViewModels.SelectViewModels;

namespace VelocityAutos.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;
        public CategoryService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CarSelectCategoryFormModel>> AllCategoriesAsync()
        {
            IEnumerable<CarSelectCategoryFormModel> categories = await repository.AllAsReadOnly<Category>()
                .Select(c => new CarSelectCategoryFormModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return categories;
        }

		public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await repository.AllAsReadOnly<Category>()
                .AnyAsync(c => c.Id == id);

            return result;
        }

		public async Task<IEnumerable<string>> AllCategoryNamesAsync()
		{
			IEnumerable<string> categoryNames = await repository.AllAsReadOnly<Category>()
				.Select(c => c.Name)
				.ToArrayAsync();

            return categoryNames;
		}
    }
}
