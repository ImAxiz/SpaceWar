using Microsoft.AspNetCore.Mvc;
using SpaceWar.Core.Dto;
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
        [HttpGet]
        public IActionResult Create()
        {
            ShipCreateViewModel vm = new();
            return View("Create", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ShipCreateViewModel vm)
        {
            var dto = new ShipDto()
            {
                ShipName = vm.ShipName,
                ShipDurability = 100,
                ShipXP = 0,
                ShipXPNextLevel = 50,
                ShipLevel = 0,
                ShipClass= (Core.Dto.ShipClass)vm.ShipClass,
                ShipStatus = (Core.Dto.ShipStatus)vm.ShipStatus,
                PrimaryAttackName = vm.PrimaryAttackName,
                PrimaryAttack = vm.PrimaryAttack,
                SecondaryAttackName = vm.SecondaryAttackName,
                SecondaryAttack = vm.SecondaryAttack,
                UltimateAttackName = vm.UltimateAttackName,
                UltimateAttack = vm.UltimateAttack,
                ShipWasBuilt = DateTime.Now,
                ShipWasDestroyed = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.imageData,
                    ImageTitle = x.ImageTitle,
                    ShipID = x.ShipID,

                }).ToArray()
            };
            var result = await _shipsServices.Create(dto);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
    }
}
