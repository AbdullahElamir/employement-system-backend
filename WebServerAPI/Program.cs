using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.DependencyInjection;
using WebServerAPI.Modules;
using WebServerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); // Use SQLite

builder.Services.AddDbContext<EmploymentSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicantServices, ApplicantServices>();
builder.Services.AddScoped<ICareerServices, CareerServices>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
