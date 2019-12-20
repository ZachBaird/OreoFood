using OreoFood.Web.Models;
using System.Configuration;
using System.Web.Mvc;

namespace OreoFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        public ActionResult Index()
        {
            var model = new GreetingViewModel() { Message = ConfigurationManager.AppSettings["message"] };

            return View(model);
        }
    }
}