using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using ClincApi.Models;
using ClinicFront.Data;
using ClinicFront.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSyncfusionBlazor();

// Register Blazorise services
builder.Services
    .AddBlazorise(options =>
    {
        options.ChangeSliderOnHold = true; // optional
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons()
    .AddLocalization();



//connect Api
var apiUri = new Uri("https://localhost:7173");

builder.Services.AddHttpClient<IUserService, UserService>(
    client => client.BaseAddress = apiUri);

builder.Services.AddHttpClient<IAdminService, AdminService>(
    client => client.BaseAddress = apiUri);

builder.Services.AddHttpClient<IServicesService, ClinicFront.Services.ServicesService>(
    client => client.BaseAddress = apiUri);

builder.Services.AddHttpClient<IDoctorServicesService, ClinicFront.Services.DoctorServicesService>(
    client => client.BaseAddress = apiUri);

builder.Services.AddHttpClient<ICategoryService, CategoryService>(
    client => client.BaseAddress = apiUri);

builder.Services.AddHttpClient<IPostService, PostService>(
    client => client.BaseAddress = apiUri);

builder.Services.AddHttpClient<IArticleService, ArticleService>(
    client => client.BaseAddress = apiUri);

builder.Services.AddHttpClient<IConsultationService, ConsultationService>(
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

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cXmVCf1NpR2pGfV5yd0VAalhSTnVXUiweQnxTdEZiWX1ccHJRRWNUUERzWw==");

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
