using HelloHotel.API.Domain.Models;
using HelloHotel.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HelloHotel.API.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Event>().ToTable("Events");
            builder.Entity<Event>().HasKey(p => p.Id);
            builder.Entity<Event>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Event>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Event>().Property(p => p.Details).IsRequired().HasMaxLength(50);
            builder.Entity<Event>().Property(p => p.Start).IsRequired().HasMaxLength(50);
            builder.Entity<Event>().Property(p => p.End).IsRequired().HasMaxLength(50);
            builder.Entity<Event>().Property(p => p.Color).IsRequired().HasMaxLength(10);
            builder.Entity<Event>().Property(p => p.Timed).IsRequired();

            builder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Waiter",
                    Details = "Work in Restaurant",
                    Start = "2021-09-28",
                    End = "2021-10-01",
                    Color = "#197602",
                    Timed = true,
                    EmployeeId = 1
                }
            );
            
            builder.Entity<Employee>().HasMany(p => p.Events)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId);

            builder.Entity<Employee>().ToTable("Employees");
            builder.Entity<Employee>().HasKey(p => p.Id);
            builder.Entity<Employee>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Employee>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            builder.Entity<Employee>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Employee>().Property(p => p.Age).IsRequired();
            builder.Entity<Employee>().Property(p => p.Email).IsRequired();
            builder.Entity<Employee>().Property(p => p.Phone).IsRequired();
            builder.Entity<Employee>().Property(p => p.Workstation).IsRequired();

            builder.Entity<Employee>().HasData(
               new Employee { 
                   Id = 1, 
                   Name = "Hernando Ernesto", 
                   LastName = "Armengol Belmonte",
                   Dni = 10625198,
                   Age = 37,
                   Email = "hernan_er@gmail.com",
                   Phone = 956139653,
                   Workstation = "Valet Service"
               } 
            );
            
            builder.UseSnakeCaseNamingConvention();
        }
        


    }
    
}