using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;
using VelocityAutos.Web.Infrastructure.Extensions;
using static VelocityAutos.Common.GeneralApplicationConstants;

var builder = WebApplication.CreateBuilder(args);

string connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<VelocityAutosDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<VelocityAutosDbContext>();

builder.Services.AddScoped<IDropboxService>(provider => new DropboxService("sl.BxFuSK3qnSzfcYPrL5HPoGI066dI4vBlVN0FOMbIc8vkTaiw9QHAfOhNUUEICIngB2282FsYSJj1b6n2Ib-we0Wv8wWsByMLqrMHyZaIbAL6d_YkCePex6Yq8njJO4QiFk7YezuJFHE6"));

builder.Services.AddApplicationServices(typeof(ICarService));
builder.Services.AddScoped<IRepository, Repository>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
});


builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });

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

app.SeedAdministrator(DevelopmentAdminEmail);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
