using RestaurantManager2021.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager2021.Data.Services
{
    public class RestaurantData : IRestaurantData
    {
        private readonly DataContext _context;

        public RestaurantData(DataContext context)
        {
            _context = context;
        }

        public void Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in _context.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {
            //WITHOUT OPTIMISTIC CONCURENCY PRINCIPLE
            //var r = Get(restaurant.Id);
            //r.Name = "";
            //_context.SaveChanges();

            //WITH OPTIMISTIC CONCURENCY PRINCIPLE
            var entry = _context.Entry(restaurant);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
