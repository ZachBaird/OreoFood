using OreoFood.Data.Models;
using System.Collections.Generic;

namespace OreoFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int id);

        void Add(Restaurant newRestaurant);
        void Update(Restaurant updRestaurant);
        void Delete(int id);
    }
}
