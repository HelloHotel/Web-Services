using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Extensions;
using HelloHotel.API.Hotel_System.Domain.Models;
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
        public DbSet<Client> Clients { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
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
            
            builder.Entity<Client>().ToTable("Clients");
            builder.Entity<Client>().HasKey(p => p.Id);
            builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Client>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            builder.Entity<Client>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Client>().Property(p => p.Age).IsRequired();
            builder.Entity<Client>().Property(p => p.Email).IsRequired();
            builder.Entity<Client>().Property(p => p.Phone).IsRequired();
            builder.Entity<Client>().Property(p => p.Room).IsRequired();

            builder.Entity<Client>().HasData(
                new Client { 
                    Id = 1, 
                    Name = "Daniela Dias", 
                    LastName = "Mora Sanchez",
                    Dni = 26227757,
                    Age = 26,
                    Email = "dani.mora@gmail.com",
                    Phone = 956189229,
                    Room = 204
                } 
            );
            
            builder.Entity<Inventory>().ToTable("Inventories");
            builder.Entity<Inventory>().HasKey(p => p.Id);
            builder.Entity<Inventory>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Inventory>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            builder.Entity<Inventory>().Property(p => p.Stock).IsRequired().HasMaxLength(30);
            builder.Entity<Inventory>().Property(p => p.MontUnit).IsRequired();
            builder.Entity<Inventory>().Property(p => p.Supplier).IsRequired();
            
            builder.Entity<Inventory>().HasData(
                new Inventory { 
                    Id = 1, 
                    Name = "Pringles", 
                    Stock = 54,
                    MontUnit = 10,
                    Supplier = "Pringles",
                } 
            );
            
            builder.Entity<Room>().ToTable("Rooms");
            builder.Entity<Room>().HasKey(p => p.Id);
            builder.Entity<Room>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Room>().Property(p => p.RoomNumber).IsRequired();
            builder.Entity<Room>().Property(p => p.Available).IsRequired().HasMaxLength(20);
            builder.Entity<Room>().Property(p => p.Client).IsRequired().HasMaxLength(30);
            builder.Entity<Room>().Property(p => p.Phone).IsRequired();
            builder.Entity<Room>().Property(p => p.DataIn).IsRequired();
            builder.Entity<Room>().Property(p => p.DateOut).IsRequired();
            builder.Entity<Room>().Property(p => p.Mont).IsRequired();
            
            builder.Entity<Room>().HasData(
                new Room { 
                    Id = 1,
                    RoomNumber = 101,
                    Available = "false", 
                    Client = "Jacinto Taboada",
                    Phone = 919133825,
                    DataIn = "24/09/2021",
                    DateOut = "25/09/2021",
                    Mont = 840
                } 
            );
            
            builder.Entity<Hotel>().ToTable("Hotels");
            builder.Entity<Hotel>().HasKey(p => p.Id);
            builder.Entity<Hotel>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Hotel>().Property(p => p.Name).IsRequired();
            builder.Entity<Hotel>().Property(p => p.Stars).IsRequired();
            builder.Entity<Hotel>().Property(p => p.Description).IsRequired().HasMaxLength(150);
            builder.Entity<Hotel>().Property(p => p.City).IsRequired();
            builder.Entity<Hotel>().Property(p => p.Photo).IsRequired();
            
            builder.Entity<Hotel>().HasData(
                new Hotel { 
                    Id = 1,
                    Name = "Holiday Inn Lima Miraflores",
                    Stars = 5, 
                    Description = "Hotel reconocido internacionalmente, cuenta con habitaciones totalmente equipadas, sala de conferencias, piscinas exteriores e interiores, servicios de limpieza y lavanderia",
                    City = "Lima",
                    Photo = "https://imgcy.trivago.com/c_lfill,d_dummy.jpeg,e_sharpen:60,f_auto,h_450,q_auto,w_450/itemimages/15/73/15733330.jpeg",
                } 
            );
            
            builder.UseSnakeCaseNamingConvention();
        }
        


    }
    
}