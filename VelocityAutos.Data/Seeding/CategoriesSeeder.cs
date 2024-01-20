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
                new Category { CategoryName = "Sedan" , Id = 1},
                new Category { CategoryName = "Coupe", Id = 2 },
                new Category { CategoryName = "Hatchback", Id = 3 },
                new Category { CategoryName = "SUV", Id = 4 },
                new Category { CategoryName = "Crossover", Id = 5 },
                new Category { CategoryName = "Convertible", Id = 6 },
                new Category { CategoryName = "Van", Id = 7 },
                new Category { CategoryName = "Pickup", Id = 8 },
                new Category { CategoryName = "Minivan", Id = 9 },
                new Category { CategoryName = "Wagon" , Id = 10 },
                new Category { CategoryName = "Limousine" , Id = 11},
                new Category { CategoryName = "Truck" , Id = 12},
                new Category { CategoryName = "Bus" , Id = 13},
                new Category { CategoryName = "Other" , Id = 14}
             };

            return categories.ToArray();
        }

    }
}