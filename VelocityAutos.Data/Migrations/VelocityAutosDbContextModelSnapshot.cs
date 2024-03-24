﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VelocityAutos.Data;

#nullable disable

namespace VelocityAutos.Data.Migrations
{
    [DbContext(typeof(VelocityAutosDbContext))]
    partial class VelocityAutosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApplicationUserCar", b =>
                {
                    b.Property<Guid>("FavouriteCarsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersFavouriteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FavouriteCarsId", "UsersFavouriteId");

                    b.HasIndex("UsersFavouriteId");

                    b.ToTable("ApplicationUserCar");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Test");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("User");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "668e7d82-3497-47eb-9098-6132d4888d53",
                            Email = "ivancars1@cars.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "IVANCARS1@CARS.COM",
                            NormalizedUserName = "IVANCARS1@CARS.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEPa7fMT+y/ZHs1GyEd0kQ9xS53uVZDrHNLOh/4vWtQ8x7zwB3e16URlliDcDEwpYbg==",
                            PhoneNumber = "0888888888",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "f49c695d-b65c-4245-a204-70ac1ef3167c",
                            TwoFactorEnabled = false,
                            UserName = "ivancars1@cars.com"
                        },
                        new
                        {
                            Id = new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3f509880-8a4c-4e64-ba38-353c1611c646",
                            Email = "dimitur122@cars.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "DIMITUR122@CARS.COM",
                            NormalizedUserName = "DIMITUR122@CARS.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAED+J21/TogJKnNZTfz/QoujvINS+2TNIlvXJzDRqp9xIm7eBm6+7B5EhuvqwRszskA==",
                            PhoneNumber = "0999999999",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "e5507714-6b85-407b-a9e4-85b8856de4bd",
                            TwoFactorEnabled = false,
                            UserName = "dimitur122@cars.com"
                        });
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FuelConsumption")
                        .HasColumnType("float");

                    b.Property<int>("FuelTypeId")
                        .HasColumnType("int");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<string>("LocationCity")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LocationCountry")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TransmissionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("TransmissionTypeId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("74576f3e-a409-46e4-a8ff-9c93eb409cba"),
                            CategoryId = 1,
                            Color = "Black",
                            Description = "The 2019 Audi A4 is a luxury compact sedan that combines sophisticated design, advanced technology, and impressive performance.",
                            FuelConsumption = 6.5,
                            FuelTypeId = 1,
                            HorsePower = 150,
                            LocationCity = "Sofia",
                            LocationCountry = "Bulgaria",
                            Make = "Audi",
                            Mileage = 10000,
                            Model = "A4",
                            Month = 3,
                            Price = 50000m,
                            TransmissionTypeId = 1,
                            Year = 2019
                        },
                        new
                        {
                            Id = new Guid("9219e817-e86a-4ea0-807f-976d8195d93a"),
                            CategoryId = 2,
                            Color = "White",
                            Description = "The Mercedes-AMG GT 63 S is a high-performance luxury four-door coupe that offers a combination of striking design, advanced technology, and powerful performance.",
                            FuelConsumption = 15.0,
                            FuelTypeId = 1,
                            HorsePower = 639,
                            LocationCity = "Sofia",
                            LocationCountry = "Bulgaria",
                            Make = "Mercedes",
                            Mileage = 5000,
                            Model = "GT63 S 4-door",
                            Month = 1,
                            Price = 200000m,
                            TransmissionTypeId = 2,
                            Year = 2023
                        });
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sedan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Coupe"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hatchback"
                        },
                        new
                        {
                            Id = 4,
                            Name = "SUV"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Crossover"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Convertible"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Van"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pickup"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Minivan"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Wagon"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Limousine"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Truck"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Bus"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Petrol"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Diesel"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Electric"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hybrid"
                        },
                        new
                        {
                            Id = 5,
                            Name = "LPG"
                        },
                        new
                        {
                            Id = 6,
                            Name = "CNG"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Ethanol"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Biodiesel"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Bioethanol"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Methanol"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Biogas"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Synthetic"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Hydrogen"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("SellerEmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerFirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SellerLastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SellerPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("SellerId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"),
                            CarId = new Guid("9219e817-e86a-4ea0-807f-976d8195d93a"),
                            CreatedOn = new DateTime(2024, 3, 4, 18, 33, 3, 246, DateTimeKind.Utc).AddTicks(8964),
                            IsActive = true,
                            SellerEmailAddress = "ivancars1@cars.com",
                            SellerFirstName = "Dimitur",
                            SellerId = new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                            SellerLastName = "Vasilev",
                            SellerPhoneNumber = "0867219923"
                        },
                        new
                        {
                            Id = new Guid("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"),
                            CarId = new Guid("74576f3e-a409-46e4-a8ff-9c93eb409cba"),
                            CreatedOn = new DateTime(2024, 3, 9, 18, 33, 3, 246, DateTimeKind.Utc).AddTicks(8976),
                            IsActive = true,
                            SellerEmailAddress = "dimitur122@cars.com",
                            SellerFirstName = "Ivan",
                            SellerId = new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                            SellerLastName = "Zdravkov",
                            SellerPhoneNumber = "0813819279"
                        });
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.TransmissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TransmissionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Manual"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Automatic"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Semi-automatic"
                        },
                        new
                        {
                            Id = 4,
                            Name = "CVT"
                        },
                        new
                        {
                            Id = 5,
                            Name = "DSG"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Tiptronic"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("ApplicationUserCar", b =>
                {
                    b.HasOne("VelocityAutos.Data.Models.Car", null)
                        .WithMany()
                        .HasForeignKey("FavouriteCarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VelocityAutos.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UsersFavouriteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("VelocityAutos.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("VelocityAutos.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VelocityAutos.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("VelocityAutos.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.Car", b =>
                {
                    b.HasOne("VelocityAutos.Data.Models.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VelocityAutos.Data.Models.FuelType", "FuelType")
                        .WithMany("Cars")
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VelocityAutos.Data.Models.TransmissionType", "TransmissionType")
                        .WithMany("Cars")
                        .HasForeignKey("TransmissionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("FuelType");

                    b.Navigation("TransmissionType");
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.Image", b =>
                {
                    b.HasOne("VelocityAutos.Data.Models.Car", "Car")
                        .WithMany("Images")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.Post", b =>
                {
                    b.HasOne("VelocityAutos.Data.Models.Car", "Car")
                        .WithOne("Post")
                        .HasForeignKey("VelocityAutos.Data.Models.Post", "CarId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VelocityAutos.Data.Models.ApplicationUser", "Seller")
                        .WithMany("OwnedPosts")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("OwnedPosts");
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.Car", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Post")
                        .IsRequired();
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.Category", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.FuelType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("VelocityAutos.Data.Models.TransmissionType", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
