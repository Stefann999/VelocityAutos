using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data.Models;

namespace VelocityAutos.Data.Seeding
{
    public class CategorieSeeder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.SeedCategories());
        }

        private Category[] SeedCategories()
        {
            ICollection<Category> categories = new HashSet<Category>()
            {
                new Category { Name = "Sedan" , Id = 1},
                new Category { Name = "Coupe", Id = 2 },
                new Category { Name = "Hatchback", Id = 3 },
                new Category { Name = "SUV", Id = 4 },
                new Category { Name = "Crossover", Id = 5 },
                new Category { Name = "Convertible", Id = 6 },
                new Category { Name = "Van", Id = 7 },
                new Category { Name = "Pickup", Id = 8 },
                new Category { Name = "Minivan", Id = 9 },
                new Category { Name = "Wagon" , Id = 10 },
                new Category { Name = "Limousine" , Id = 11},
                new Category { Name = "Truck" , Id = 12},
                new Category { Name = "Bus" , Id = 13},
                new Category { Name = "Other" , Id = 14}
             };

            return categories.ToArray();
        }

    }
}