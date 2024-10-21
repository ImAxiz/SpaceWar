using Microsoft.Extensions.Hosting;
using SpaceWar.Core.Domain;
using SpaceWar.Core.Dto;
using SpaceWar.Core.ServiceInterface;
using SpaceWar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly SpaceWarContext _context;

        public FileServices
            (
                IHostEnvironment webHost,
                SpaceWarContext context
            
            )
        {
            _webHost = webHost;
            _context = context;
        }

        public void UploadFilesToDatabase(ShipDto dto, Ship domain)
        {
            if ( dto.Files != null && dto.Files.Count > 0 ) 
            { 
                foreach ( var image in dto.Files ) 
                {
                    using (var target = new MemoryStream()) 
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            ShipID = domain.Id,
                        };

                        image.CopyTo( target );
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add( files );

                    }
                }
            }
        }

    }
}
