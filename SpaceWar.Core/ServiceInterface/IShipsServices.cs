using SpaceWar.Core.Domain;
using SpaceWar.Core.Dto;
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
        Task<Ship> Create(ShipDto dto);
        Task<Ship> Update(ShipDto dto);
    }
}
