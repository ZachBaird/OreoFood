using OreoFood.Data.Models;
using OreoFood.Data.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace OreoFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        IRestaurantData _db;

        public RestaurantsController(IRestaurantData db)
        {
            _db = db;
        }

        public IEnumerable<Restaurant> Get()
        {
            var model = _db.GetAll();

            return model;
        }
    }
}
