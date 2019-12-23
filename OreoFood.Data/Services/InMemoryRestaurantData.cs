using OreoFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OreoFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Slice of Brooklyn", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Hitesh's Joint", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "La maison de Bernard", Cuisine = CuisineType.French }
            };
        }

        public void Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(newRestaurant);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public Restaurant GetById(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Update(Restaurant updRestaurant)
        {
            var existing = GetById(updRestaurant.Id);

            if(existing != null)
            {
                existing.Name = updRestaurant.Name;
                existing.Cuisine = updRestaurant.Cuisine;
            }
        }
    }
}
