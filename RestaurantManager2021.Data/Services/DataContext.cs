using RestaurantManager2021.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager2021.Data.Services
{
    public class DataContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
