using VelocityAutos.Services.Mapping;

namespace VelocityAutos.Web.ViewModels.Car
{
    using AutoMapper;
    using Data.Models;

    public class CarDeleteViewModel : IMapTo<Car>, IHaveCustomMappings
    {
        public string Id { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public decimal Price { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public string SellerId { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, CarDeleteViewModel>()
                .ForMember(d => d.SellerId,
                opt => opt.MapFrom(s => Guid.Parse(s.Post.SellerId.ToString())));
        }
    }
}
