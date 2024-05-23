using EmployeeManagement.Core.Models;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<EmployeePosition> EmployeePositions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeePosition>()
            .HasKey(pe => new { pe.EmployeeId, pe.PositionId });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Employees_ManagementDB");
    }

    public List<Employee> GetEmployeesBySql()
    {
        return Employees.FromSqlRaw("SELECT * FROM Employees WHERE IsActive = 1").ToList();
    }

}
