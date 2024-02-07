using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.ViewModels.SelectViewModels;

namespace VelocityAutos.Services.Data
{
    public class TransmissionTypeService : ITransmissionTypeService
    {
        private readonly VelocityAutosDbContext dbContext;
        public TransmissionTypeService(VelocityAutosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CarSelectTransmissionFormModel>> AllTransmissionTypesAsync()
        {
            IEnumerable<CarSelectTransmissionFormModel> transmissionTypes = await this.dbContext
                .TransmissionTypes
                .AsNoTracking()
                .Select(c => new CarSelectTransmissionFormModel
                {
                    Id = c.Id,
                    Name = c.TransmissionTypeName
                })
                .ToArrayAsync();

            return transmissionTypes;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .TransmissionTypes
                .AnyAsync(c => c.Id == id);

            return result;
        }
    }
}
