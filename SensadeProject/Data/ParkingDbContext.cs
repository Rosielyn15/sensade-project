using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SensadeProject.Models;

namespace SensadeProject.Data
{
    public class ParkingDbContext : DbContext
    {
        public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Parkinglot> ParkingLots { get; set; }
        public DbSet<Parkingspace> ParkingSpaces { get; set; }
    }
}