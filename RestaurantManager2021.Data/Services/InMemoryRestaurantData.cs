using RestaurantManager2021.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManager2021.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name="Peking Garden", Cuisine = CuisineType.Chinese},
                new Restaurant{Id = 2, Name="Dion", Cuisine = CuisineType.Misc},
                new Restaurant{Id = 3, Name="Soul and Kitchen", Cuisine = CuisineType.Misc },
                new Restaurant{Id = 4, Name="La Terazza", Cuisine = CuisineType.Italian}
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Delete(int id)
        {
            var restaurant = Get(id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(x => x.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
    }
}
