using OreoFood.Web.Models;
using System.Configuration;
using System.Web.Mvc;

namespace OreoFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel()
            { 
                Name = name ?? "no name",
                Message = ConfigurationManager.AppSettings["message"] 
            };

            return View(model);
        }
    }
}