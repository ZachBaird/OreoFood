﻿using OreoFood.Data.Models;
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

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}