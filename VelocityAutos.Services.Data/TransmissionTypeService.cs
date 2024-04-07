using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;
using VelocityAutos.Web.ViewModels.SelectViewModels;

namespace VelocityAutos.Services.Data
{
    public class TransmissionTypeService : ITransmissionTypeService
    {
        private readonly IRepository repository;
        public TransmissionTypeService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CarSelectTransmissionFormModel>> AllTransmissionTypesAsync()
        {
            IEnumerable<CarSelectTransmissionFormModel> transmissionTypes = await repository.AllAsReadOnly<TransmissionType>()
                .Select(c => new CarSelectTransmissionFormModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return transmissionTypes;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await repository.AllAsReadOnly<TransmissionType>()
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<IEnumerable<string>> AllTransmissionTypeNamesAsync()
        {
			IEnumerable<string> transmissionTypesNames = await repository.AllAsReadOnly<Category>()
	            .Select(c => c.Name)
	            .ToArrayAsync();

			return transmissionTypesNames;
		}
    }
}
