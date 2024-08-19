using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebServerAPI.Modules;
using WebServerAPI.Repository;


var builder = WebApplication.CreateBuilder(args);

// Configure the database context with connection string from appsettings.json
builder.Services.AddDbContext<EmploymentSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repository and service
builder.Services.AddScoped<IExperienceReqRepository, ExperienceReqRepository>();
builder.Services.AddScoped<IExperienceReqService, ExperienceReqService>();

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
