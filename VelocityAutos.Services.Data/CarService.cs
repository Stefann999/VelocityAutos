using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Data;
using Microsoft.EntityFrameworkCore;

namespace VelocityAutos.Services.Data
{
    public class CarService : ICarService
    {
        private readonly VelocityAutosDbContext dbContext;

        public CarService(VelocityAutosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ExistsByIdAsync(string carId)
        {
            bool result = await this.dbContext
                .Cars
                .AnyAsync(c => c.Id.ToString() == carId);

            return result;
        }
    }
}
