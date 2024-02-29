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

builder.Services.AddScoped<IDropboxService>(provider => new DropboxService("sl.BwinUuDEgh24ijMkVF6D2R1nC-zz5CDyJRFnu0Sm9X-FAyXUzZ1bx5tEgWBCOweQisIRca0dILloN6SYmGRfsZO0FcoXc4CBG7EPpg4rIRUyIKT_a71fncTWT4hdpPLoCWeGVHyu4EN3"));


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
