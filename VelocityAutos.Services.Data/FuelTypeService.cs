using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.ViewModels.FuelType;

namespace VelocityAutos.Services.Data
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly VelocityAutosDbContext dbContext;

        public FuelTypeService(VelocityAutosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CarSelectFuelTypeFormModel>> AllFuelTypesAsync()
        {
            IEnumerable<CarSelectFuelTypeFormModel> fuelTypes = await this.dbContext
                .FuelTypes
                .AsNoTracking()
                .Select(c => new CarSelectFuelTypeFormModel
                {
                    Id = c.Id,
                    Name = c.FuelTypeName
                })
                .ToArrayAsync();

            return fuelTypes;
        }
    }
}
