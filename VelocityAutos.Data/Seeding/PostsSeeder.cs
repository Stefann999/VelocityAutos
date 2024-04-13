using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data.Models;

namespace VelocityAutos.Data.Seeding
{
    public class PostsSeeder : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(this.SeedPosts());
        }

        private Post[] SeedPosts()
        {
            ICollection<Post> posts = new HashSet<Post>()
            {
                new Post { Id = Guid.Parse("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"), CreatedOn = DateTime.UtcNow.AddDays(-20), SellerId = Guid.Parse("66543f29-bafc-4680-8028-5c4b7e444ccb"), CarId = Guid.Parse("9219E817-E86A-4EA0-807F-976D8195D93A"), SellerFirstName = "Ivan", SellerLastName = "Stoilov", SellerPhoneNumber = "0867219923" , SellerEmailAddress = "ivancars1@cars.com", IsActive = true},
                new Post { Id = Guid.Parse("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"), CreatedOn = DateTime.UtcNow.AddDays(-15), SellerId = Guid.Parse("ed670787-a2d5-45e9-a069-83dcd8e84e30"), CarId = Guid.Parse("74576F3E-A409-46E4-A8FF-9C93EB409CBA"), SellerFirstName = "Dimitur", SellerLastName = "Vasilev", SellerPhoneNumber = "0813819279" , SellerEmailAddress = "dimitur122@cars.com", IsActive = true}
             };

            return posts.ToArray();
        }
    }
}
