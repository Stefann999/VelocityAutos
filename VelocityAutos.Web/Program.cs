using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Extensions;
using static Dropbox.Api.TeamLog.EventCategory;

var builder = WebApplication.CreateBuilder(args);

string connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<VelocityAutosDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<VelocityAutosDbContext>();

builder.Services.AddScoped<IDropboxService>(provider => new DropboxService("sl.BuItAS_rgfx35HYwkd0zJLo71CaB9XdbITVVL9oUThA-Y7P3-_LnwFWEelT4BsEJQpusP9tQVLlfSB9zlF1SELFYcd8Ndw5Dr6ZlKRSM0CfwBKei5rLee3zDhJaA828OMmIeaoU-mmCf"));


builder.Services.AddApplicationServices(typeof(ICarService));


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
