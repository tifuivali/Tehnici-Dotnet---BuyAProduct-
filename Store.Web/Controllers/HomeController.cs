using System.Web.Mvc;
using Store.Web.Security;

namespace Store.Web.Controllers
{
    public class HomeController : Controller
    {
        [AuthorizeUsers]
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeUsers]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AuthorizeUsers]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}