﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.Core.Dto
{
    public class ShipOwnershipDto : ShipDto
    {
        public Guid OwnershipID { get; set; }
        public int ShipDurability { get; set; }
        public int ShipXP { get; set; }
        public int ShipXPNextLevel { get; set; }
        public int ShipLevel { get; set; }
        public ShipStatus ShipStatus { get; set; }
        public int PrimaryAttackPower { get; set; }
        public int SecondaryAttackPower { get; set; }
        public int SpecialAttackPower { get; set; }
        public DateTime ShipWasBuilt { get; set; }
        public DateTime ShipWasDestroyed { get; set; }
        //public string OwnedByPlayerProfile { get; set; } //is string but holds guid

        //db only
        public DateTime OwnershipCreatedAt { get; set; }
        public DateTime OwnershipUpdatedAt { get; set; }
    }
}
