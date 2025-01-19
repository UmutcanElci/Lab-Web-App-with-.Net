using Lab.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab.Infrasturcture.Data;

public class LabAppDbContext : DbContext
{
    public DbSet<Report> Reports { get; set; }

    public LabAppDbContext(DbContextOptions options) : base(options){}
}