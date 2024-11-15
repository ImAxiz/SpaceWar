using SpaceWar.Core.Domain;
using SpaceWar.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.Core.ServiceInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(ShipDto dto, Ship domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabase dto);
    }
}
