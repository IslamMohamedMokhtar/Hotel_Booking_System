using HotelSystem.Model.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace HotelSystem.Data
{
    public class HotelDbContext(DbContextOptions<HotelDbContext> options) : DbContext(options)
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<Hotel>().HasData(new Hotel {Id =1, Name = "Sheaton Hotel" },
                 new Hotel {Id =2, Name = "Helnan Hotel" },
                 new Hotel {Id =3, Name = "Tolip Hotel" }
                 );
             modelBuilder.Entity<Room>().HasData(new Room {Id =1, Specification = "Double Room Sea View", Price = 200, HotelId = 1 },
                 new Room {Id =2, Specification = "Single Room Sea View", Price = 150, HotelId = 1 },
                 new Room {Id =3, Specification = "Double Room City View", Price = 179, HotelId = 1 },
                 new Room {Id =4, Specification = "Single Room City View", Price = 120, HotelId = 1 },
                 new Room {Id =5, Specification = "Double Room Garden View", Price = 100, HotelId = 2 },
                 new Room {Id =6, Specification = "Single Room Garden View", Price = 90, HotelId = 2 },
                 new Room {Id =7, Specification = "Double Room Pool View", Price = 120, HotelId = 2 },
                 new Room {Id =8, Specification = "Single Room Pool View", Price = 110, HotelId = 2 },
                 new Room {Id =9, Specification = "Double Room Standard", Price = 80, HotelId = 3 },
                 new Room {Id =10, Specification = "Single Room Standard", Price = 70, HotelId = 3 },
                 new Room {Id =11, Specification = "Double Room Deluxe", Price = 100, HotelId = 3 },
                 new Room {Id =12, Specification = "Single Room Deluxe", Price = 95, HotelId = 3 }
                 );

         }
    }
}
