using Lab.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab.Infrasturcture.Data;

public class LabAppDbContext : DbContext
{
   

    public LabAppDbContext(DbContextOptions options) : base(options){}
    public DbSet<Report> Reports { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
}