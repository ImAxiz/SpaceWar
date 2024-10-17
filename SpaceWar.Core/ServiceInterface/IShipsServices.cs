using SpaceWar.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.Core.ServiceInterface
{
    public interface IShipsServices
    {
        Task<Ship> DetailsAsync(Guid id);
    }
}
