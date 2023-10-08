using ClincApi.Models;
using ClinicFront.Data;
using ClinicFront.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


//connect Api
var apiUri = new Uri("https://localhost:7173");

builder.Services.AddHttpClient<IUserService, UserService>(
    client => client.BaseAddress = apiUri);

builder.Services.AddHttpClient<IAdminService, AdminService>(
    client => client.BaseAddress = apiUri);

builder.Services.AddHttpClient<IDoctorService, ClinicFront.Services.DoctorService>(
    client => client.BaseAddress = apiUri);

builder.Services.AddHttpClient<ICategoryService, CategoryService>(
    client => client.BaseAddress = apiUri);


builder.Services.AddDbContext<ClinicDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("default")));


//Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options => //Identity
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedEmail = false;

})
   .AddEntityFrameworkStores<ClinicDBContext>()
   .AddDefaultTokenProviders();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
