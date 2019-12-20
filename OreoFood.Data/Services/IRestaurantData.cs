using OreoFood.Data.Models;
using System.Collections.Generic;

namespace OreoFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}
