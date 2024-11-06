using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.Core.Domain
{
     public enum ShipClass
    {
        Destroyer, Cargo, Support, LongRange, NukeCarrier, Unknown
    }

     public enum ShipStatus
    {
        Exists, Destoryed, Lost
    }

    public class Ship
    {
        public Guid Id { get; set; }
        public string ShipName { get; set; }
        public int ShipXP { get; set; }
        public int ShipXPNextLevel { get; set; }
        public int ShipDurability { get; set; }
        public int ShipLevel { get; set; }
        public ShipClass ShipClass { get; set; }
        public ShipStatus ShipStatus { get; set; }
        public string PrimaryAttack { get; set; }
        public int PrimaryAttackPower { get; set; }
        public string SecondaryAttack { get;set; }
        public int SecondaryAttackPower { get; set; }
        public string UltimateAttack { get;set; }
        public int UltimateAttackPower { get; set; }
        public DateTime ShipWasBuilt { get; set; }
        public DateTime ShipWasDestroyed { get; set; }

        //db only

        public DateTime BuiltAt { get; set; }
        public DateTime DestroyedAt { get; set; }


    }
}
