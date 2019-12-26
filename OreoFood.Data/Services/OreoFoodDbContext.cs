using OreoFood.Data.Models;
using System.Data.Entity;

namespace OreoFood.Data.Services
{
    public class OreoFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
