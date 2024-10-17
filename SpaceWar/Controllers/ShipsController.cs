using Microsoft.AspNetCore.Mvc;
using SpaceWar.Core.ServiceInterface;
using SpaceWar.Data;
using SpaceWar.Models.Ships;

namespace SpaceWar.Controllers
{
    public class ShipsController : Controller
    {
        /*
         * ShipsController kontrollib kõike funktsioone shippidele.
         */

        private readonly SpaceWarContext _context;
        private readonly IShipsServices _shipsServices;
        public ShipsController(SpaceWarContext context, IShipsServices shipsServices)
        {
            _context = context;
            _shipsServices = shipsServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var resultingInventory = _context.Ships
                .OrderByDescending(y => y.ShipLevel)
                .Select(x => new ShipIndexViewModel
                {
                    Id = x.Id,
                    ShipName = x.ShipName,
                    ShipClass = (ShipClass)x.ShipClass,
                    ShipLevel = x.ShipLevel,
                });
            return View(resultingInventory);
        }
    }
}
