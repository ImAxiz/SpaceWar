using Microsoft.EntityFrameworkCore;
using SpaceWar.Core.Domain;
using SpaceWar.Core.Dto;
using SpaceWar.Core.ServiceInterface;
using SpaceWar.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.ApplicationServices.Services
{
    public class ShipsServices : IShipsServices
    {
        private readonly SpaceWarContext _context;
        private readonly IFileServices _fileServices;

        public ShipsServices(SpaceWarContext context , IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }

        /// <summary>
        /// Get Details for on ship
        /// </summary>
        /// <param name="id">Id of ship to show details of</param>
        /// <returns>resulting ship</returns>

        public async Task<Ship> DetailsAsync(Guid id)
        {
            var result = await _context.Ships
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Ship> Create(ShipDto dto)
        {
            Ship ship = new Ship();

            //set by service
            ship.Id = Guid.NewGuid();
            ship.ShipDurability = 100;
            ship.ShipXP = 0;
            ship.ShipXPNextLevel = 50;
            ship.ShipLevel = 0;
            ship.ShipStatus = Core.Domain.ShipStatus.Exists;
            ship.ShipWasBuilt = DateTime.Now;
            ship.ShipWasDestroyed = DateTime.Parse("01 / 01 / 9999, 00,00,00");


            //set by user
            ship.ShipClass = (Core.Domain.ShipClass)dto.ShipClass;
            ship.PrimaryAttack = dto.PrimaryAttack;
            ship.PrimaryAttackPower = dto.PrimaryAttackPower;
            ship.SecondaryAttack = dto.SecondaryAttack;
            ship.UltimateAttack = dto.UltimateAttack;
            ship.UltimateAttackPower = dto.UltimateAttackPower;

            //set for db
            ship.BuiltAt = DateTime.Now;
            ship.DestroyedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, ship);
            }

            await _context.Ships.AddAsync(ship);
            await _context.SaveChangesAsync();

            return ship;
        }
    }
}
