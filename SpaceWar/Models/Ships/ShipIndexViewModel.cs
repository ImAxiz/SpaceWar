using System.Net.NetworkInformation;

namespace SpaceWar.Models.Ships
{
    public enum ShipClass
    {
        Destroyer, Cargo, Support, LongRange, NukeCarrier, FighterCarrier, Unknown
    }

    public enum ShipStatus
    {
        Exists, Destoryed, Lost
    }
    public class ShipIndexViewModel
    {
        public Guid Id { get; set; }
        public string ShipName { get; set; }
        public int ShipDurability { get; set; }
        public int ShipXP { get; set; }
        public int ShipXPNextLevel { get; set; }
        public int ShipLevel { get; set; }
        public ShipClass ShipClass { get; set; }
        public ShipStatus ShipStatus { get; set; }
        public int PrimaryAttack { get; set; }
        public string PrimaryAttackName { get; set; }
        public int SecondaryAttack { get; set; }
        public string SecondaryAttackName { get; set; }
        public int UltimateAttack { get; set; }
        public string UltimateAttackName { get; set; }
        public DateTime ShipWasBuilt { get; set; }
        public DateTime ShipWasDestroyed { get; set; }

        //db only

        public DateTime Built { get; set; }
        public DateTime Destroyed { get; set; }
    }
}
