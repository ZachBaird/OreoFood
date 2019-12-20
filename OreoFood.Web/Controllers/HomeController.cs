using OreoFood.Data.Services;
using System.Web.Mvc;

namespace OreoFood.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData _db;

        public HomeController(IRestaurantData db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var model = _db.GetAll();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}