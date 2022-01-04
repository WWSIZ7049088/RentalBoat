using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoatRental.Models;

namespace BoatRental.Data
{
    public class BoatRentalContext : DbContext
    {
        public BoatRentalContext (DbContextOptions<BoatRentalContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Boat> Boat { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Boat>().ToTable("Boat");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
        }
    }
}
