using Microsoft.EntityFrameworkCore;
using PetTracker.Models;
using System.Collections;

namespace PetTracker.DbPets
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       public DbSet<Pet> Pets { get; set; }

    }
}
