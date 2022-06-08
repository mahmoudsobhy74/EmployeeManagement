using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Models;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Department>().HasKey(e=>e.DepartmentId);
        builder.Entity<Department>().HasMany(e=>e.Employees).WithOne(e=>e.Department).HasForeignKey(e=>e.DepartmentId);
        builder.Entity<Department>().HasOne(e => e.Manager).WithMany().HasForeignKey(e => e.ManagerId);


        builder.Entity<Employee>().HasKey(e => e.EmployeeID);
        builder.Entity<Employee>().HasOne(e => e.Department).WithMany(e => e.Employees).HasForeignKey(e => e.DepartmentId);
        builder.Entity<Employee>().HasOne(e => e.Manager).WithMany();
    }
}
