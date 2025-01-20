using Lab.App.Interfaces;
using Lab.App.Services;
using Lab.Infrasturcture.Data;
using Lab.Infrasturcture.Repositories.Implementations;
using Lab.Infrasturcture.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<LabAppDbContext>(opt =>
    opt.UseMySQL(
        builder.Configuration.GetConnectionString("DefaultConnection")!)
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine));

builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportService, ReportService>(); 

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
