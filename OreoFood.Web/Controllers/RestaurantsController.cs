using OreoFood.Data.Models;
using OreoFood.Data.Services;
using System.Web.Mvc;

namespace OreoFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        IRestaurantData _db;

        public RestaurantsController(IRestaurantData db)
        {
            _db = db;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _db.GetById(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // This method is receiving the user data from the Create Restaurant form. Because of the form name attributes,
        //  we can tell the Controller we're expecting certain values that it can automatically plug in for us using
        //  "model-binding".
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                _db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.GetById(id);

            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant updatedRestaurant)
        {
            if(ModelState.IsValid)
            {
                _db.Update(updatedRestaurant);
                TempData["Message"] = "You have saved the restaurant";
                return RedirectToAction("Details", new { id = updatedRestaurant.Id });
            }

            return View(updatedRestaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _db.GetById(id);

            if(model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            _db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}