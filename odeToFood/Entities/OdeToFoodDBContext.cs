using System;
using Microsoft.EntityFrameworkCore;

namespace odeToFood.Entities
{
    public class OdeToFoodDBContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
