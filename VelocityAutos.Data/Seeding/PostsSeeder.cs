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
                new Post { Id = Guid.Parse("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"), CreatedOn = DateTime.UtcNow.AddDays(-15), SellerId = Guid.Parse("ed670787-a2d5-45e9-a069-83dcd8e84e30"), CarId = Guid.Parse("74576F3E-A409-46E4-A8FF-9C93EB409CBA"), SellerFirstName = "Dimitur", SellerLastName = "Vasilev", SellerPhoneNumber = "0813819279" , SellerEmailAddress = "dimitur122@cars.com", IsActive = true},
                new Post { Id = Guid.Parse("042963e9-c983-4253-ad5b-c5a75c894dd8"), CreatedOn = DateTime.UtcNow.AddDays(-18), SellerId = Guid.Parse("ed670787-a2d5-45e9-a069-83dcd8e84e30"), CarId = Guid.Parse("c48b7dcd-0d04-4a56-bfe0-df00eb6812b5"), SellerFirstName = "Dimitur", SellerLastName = "Vasilev", SellerPhoneNumber = "0813819279" , SellerEmailAddress = "dimitur122@cars.com", IsActive = true},
                new Post { Id = Guid.Parse("7af043e6-1324-4a7a-89ac-45a02945d6a1"), CreatedOn = DateTime.UtcNow.AddDays(-1), SellerId = Guid.Parse("66543f29-bafc-4680-8028-5c4b7e444ccb"), CarId = Guid.Parse("f6707b62-64e1-415f-af35-eb635f988c47"), SellerFirstName = "Ivan", SellerLastName = "Stoilov", SellerPhoneNumber = "0867219923" , SellerEmailAddress = "ivancars1@cars.com", IsActive = true},
                new Post { Id = Guid.Parse("e050004c-40e3-4edc-95ef-72beff4b2377"), CreatedOn = DateTime.UtcNow.AddDays(-24), SellerId = Guid.Parse("66543f29-bafc-4680-8028-5c4b7e444ccb"), CarId = Guid.Parse("82f03f75-cfb3-4434-bb73-f8c5dcf4109d"), SellerFirstName = "Ivan", SellerLastName = "Stoilov", SellerPhoneNumber = "0867219923" , SellerEmailAddress = "ivancars1@cars.com", IsActive = true},
                new Post { Id = Guid.Parse("f37270cc-5251-4255-add7-f837b01e6453"), CreatedOn = DateTime.UtcNow.AddDays(-18), SellerId = Guid.Parse("ed670787-a2d5-45e9-a069-83dcd8e84e30"), CarId = Guid.Parse("fd1f3b19-7e3b-4fec-a1b0-e47188884a42"), SellerFirstName = "Dimitur", SellerLastName = "Vasilev", SellerPhoneNumber = "0813819279" , SellerEmailAddress = "dimitur122@cars.com", IsActive = true},
             };

            return posts.ToArray();
        }
    }
}
