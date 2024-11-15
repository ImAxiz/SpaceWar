using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceWar.ApplicationServices.Services;
using SpaceWar.Core.Dto;
using SpaceWar.Core.ServiceInterface;
using SpaceWar.Data;
using SpaceWar.Models.Ships;
using static System.Net.Mime.MediaTypeNames;

namespace SpaceWar.Controllers
{
    public class ShipsController : Controller
    {
        /*
         * ShipsController kontrollib kõike funktsioone shippidele.
         */

        private readonly SpaceWarContext _context;
        private readonly IShipsServices _shipsServices;
        private readonly IFileServices _fileServices;
        public ShipsController(SpaceWarContext context, IShipsServices shipsServices, IFileServices fileServices)
        {
            _context = context;
            _shipsServices = shipsServices;
            _fileServices = fileServices;
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
                    ShipClass = (Models.Ships.ShipClass)(Core.Dto.ShipClass)x.ShipClass,
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
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
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
                PrimaryAttackPower = vm.PrimaryAttackPower,
                PrimaryAttack = vm.PrimaryAttack,
                SecondaryAttackPower = vm.SecondaryAttackPower,
                SecondaryAttack = vm.SecondaryAttack,
                UltimateAttackPower = vm.UltimateAttackPower,
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
        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var ship = await _shipsServices.DetailsAsync(id);

            if (ship == null)
            {
                return NotFound(); // <-- TODO; custom partial view with message, ship is not located
            }

            var images = await _context.FilesToDatabase
                .Where(t => t.ShipID == id)
                .Select(y => new ShipImageViewModel
                {
                    ShipID = y.ID,
                    ImageID = y.ID,
                    imageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new ShipDetailsViewModel();
            vm.Id = ship.Id;
            vm.ShipName = ship.ShipName;
            vm.ShipDurability = ship.ShipDurability;
            vm.ShipXP = ship.ShipXP;
            vm.ShipLevel = ship.ShipLevel;
            vm.PrimaryAttack = ship.PrimaryAttack;
            vm.PrimaryAttackPower = ship.PrimaryAttackPower;
            vm.SecondaryAttack = ship.SecondaryAttack;
            vm.SecondaryAttackPower = ship.SecondaryAttackPower;
            vm.UltimateAttack = ship.UltimateAttack;
            vm.UltimateAttackPower = ship.UltimateAttackPower;
            vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _shipsServices.DetailsAsync(id);

            if (ship == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(t => t.ShipID == id)
                .Select(y => new ShipImageViewModel
                {
                    ShipID = y.ID,
                    ImageID = y.ID,
                    imageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new ShipDetailsViewModel();
            vm.Id = ship.Id;
            vm.ShipName = ship.ShipName;
            vm.ShipDurability = ship.ShipDurability;
            vm.ShipXP = ship.ShipXP;
            vm.ShipLevel = ship.ShipLevel;
            vm.PrimaryAttack = ship.PrimaryAttack;
            vm.PrimaryAttackPower = ship.PrimaryAttackPower;
            vm.SecondaryAttack = ship.SecondaryAttack;
            vm.SecondaryAttackPower = ship.SecondaryAttackPower;
            vm.UltimateAttack = ship.UltimateAttack;
            vm.UltimateAttackPower = ship.UltimateAttackPower;
            vm.Image.AddRange(images);

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ShipCreateViewModel vm)
        {
            var dto = new ShipDto()
            {
                Id = (Guid)vm.Id,
                ShipName = vm.ShipName,
                ShipDurability = 100,
                ShipXP = 0,
                ShipXPNextLevel = 50,
                ShipLevel = 0,
                ShipClass = (Core.Dto.ShipClass)vm.ShipClass,
                ShipStatus = (Core.Dto.ShipStatus)vm.ShipStatus,
                PrimaryAttackPower = vm.PrimaryAttackPower,
                PrimaryAttack = vm.PrimaryAttack,
                SecondaryAttackPower = vm.SecondaryAttackPower,
                SecondaryAttack = vm.SecondaryAttack,
                UltimateAttackPower = vm.UltimateAttackPower,
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
            var result = await _shipsServices.Update(dto);

            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var ship = await _shipsServices.DetailsAsync(id);

            if (ship == null) { return NotFound();}

            var images = await _context.FilesToDatabase
                .Where(x => x.ShipID == id)
                .Select( y => new ShipImageViewModel
                {
                    ShipID = y.ID,
                    ImageID = y.ID,
                    imageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base4,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new ShipDeleteViewModel();

            vm.Id = ship.Id;
            vm.ShipName = ship.ShipName;
            vm.ShipDurability = ship.ShipDurability;
            vm.ShipXP = ship.ShipXP;
            vm.ShipLevel = ship.ShipLevel;
            vm.PrimaryAttack = ship.PrimaryAttack;
            vm.PrimaryAttackPower = ship.PrimaryAttackPower;
            vm.SecondaryAttack = ship.SecondaryAttack;
            vm.SecondaryAttackPower = ship.SecondaryAttackPower;
            vm.UltimateAttack = ship.UltimateAttack;
            vm.UltimateAttackPower = ship.UltimateAttackPower;
            vm.Image.AddRange(images);

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var shipToDelete = await _shipsServices.Delete(id);

            if (shipToDelete == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(ShipImageViewModel vm)
        {
            var dto = new FileToDatabaseDto()
            {
                ID = vm.ImageID
            };
            var image = await _fileServices.RemoveImageFromDatabase(dto);
            if (image == null) 
            { 
                return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(ShipImageViewModel vm)
        {
            var dto = new FileToDatabaseDto()
            {
                ID = vm.ImageID
            };
            var image = await _fileServices.RemoveImageFromDatabase(dto);
            if (image == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
