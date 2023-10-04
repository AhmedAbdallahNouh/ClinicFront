using ClincApi.Models;
using ClincApi.Repositeries;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
var text = "";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(text,
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
        //builder.AllowCredentials();
    });
});

//Inject Repo   
builder.Services.AddScoped<IDoctorServiceRepo , DoctorServiceRepo>();
builder.Services.AddScoped<ICategoryRepo , CategoryRepo>();
builder.Services.AddScoped<IPostsRepo , PostsRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//CORS
app.UseCors(x => x
           .AllowAnyMethod()
           .AllowAnyHeader()
           .SetIsOriginAllowed(origin => true)
           .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
