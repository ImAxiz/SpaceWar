using Microsoft.AspNetCore.Mvc;

namespace SpaceWar.Controllers
{
    public class ShipsController : Controller
    {
        /*
         * ShipsController kontrollib kõike funktsioone shippidele.
         */
        public IActionResult Index()
        {
            return View();
        }
    }
}
