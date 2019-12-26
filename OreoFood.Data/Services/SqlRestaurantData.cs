using OreoFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OreoFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        OreoFoodDbContext _db;

        public SqlRestaurantData(OreoFoodDbContext db)
        {
            _db = db;
        }

        public void Add(Restaurant newRestaurant)
        {
            _db.Restaurants.Add(newRestaurant);
            _db.SaveChanges();
        }        

        public IEnumerable<Restaurant> GetAll()
        {
            return _db.Restaurants
                      .OrderBy(r => r.Name);
        }

        public Restaurant GetById(int id)
        {
            return _db.Restaurants
                      .FirstOrDefault(r => r.Id == id);
        }

        public void Update(Restaurant updRestaurant)
        {
            var r = GetById(updRestaurant.Id);
            r.Name = updRestaurant.Name;
            r.Cuisine = updRestaurant.Cuisine;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = _db.Restaurants.Find(id);

            if(restaurant != null)
            {
                _db.Restaurants.Remove(restaurant);
                _db.SaveChanges();
            }
        }
    }
}
