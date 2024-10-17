using Microsoft.EntityFrameworkCore;
using SpaceWar.Core.Domain;
using SpaceWar.Core.ServiceInterface;
using SpaceWar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.ApplicationServices.Services
{
    public class ShipsServices : IShipsServices
    {
        private readonly SpaceWarContext _context;
        public ShipsServices(SpaceWarContext context /*, IFileServices fileServices */)
        {
            _context = context;
            //_fileServices = fileServices
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
    }
}
