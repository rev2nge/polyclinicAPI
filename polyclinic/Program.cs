using polyclinic.Models;
using polyclinic.Helper;
using Microsoft.EntityFrameworkCore;
using polyclinic.Data.Repository;
using polyclinic.Interface;
using polyclinic.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var secretKey = builder.Configuration.GetSection("AppSettings:Key").Value;
var key = new SymmetricSecurityKey(Encoding.UTF8
    .GetBytes(secretKey));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                // services.AddAuthentication("Bearer")
                .AddJwtBearer(opt => {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = key
                    };
                });

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
//builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=medicDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"));
var app = builder.Build();

//void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//{
//    app.ConfigureExceptionHandler(env);
//}



app.UseStaticFiles();
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();
app.UseAuthentication();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=City}/{action=CreateCity}");

app.MapFallbackToFile("index.html");

app.Run();
