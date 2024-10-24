﻿using Microsoft.EntityFrameworkCore;
using SpaceWar.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpaceWar.Data
{
    public class SpaceWarContext : DbContext
    {
        public SpaceWarContext(DbContextOptions<SpaceWarContext> options) : base(options) {}
        public DbSet<Ship> Ships { get; set; }

        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
    }
}
