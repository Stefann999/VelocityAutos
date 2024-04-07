using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;
using VelocityAutos.Web.ViewModels.FuelType;

namespace VelocityAutos.Services.Data
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly IRepository repository;

        public FuelTypeService(IRepository repository)
        {
            this.repository = repository;
        }

		public async Task<IEnumerable<CarSelectFuelTypeFormModel>> AllFuelTypesAsync()
        {
            IEnumerable<CarSelectFuelTypeFormModel> fuelTypes = await repository.AllAsReadOnly<FuelType>()
                .Select(c => new CarSelectFuelTypeFormModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return fuelTypes;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await repository.AllAsReadOnly<FuelType>()
                .AnyAsync(c => c.Id == id);

            return result;
        }

		public async Task<IEnumerable<string>> AllFuelTypeNamesAsync()
		{
			IEnumerable<string> fuelTypesNames = await repository.AllAsReadOnly<FuelType>()
				.Select(c => c.Name)
				.ToArrayAsync();

			return fuelTypesNames;
		}
    }
}
