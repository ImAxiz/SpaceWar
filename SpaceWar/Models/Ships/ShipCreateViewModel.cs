namespace SpaceWar.Models.Ships
{
    public class ShipCreateViewModel
    {
            public Guid Id { get; set; }
            public string ShipName { get; set; }
            public int ShipDurability { get; set; }
            public int ShipXP { get; set; }
            public int ShipXPNextLevel { get; set; }
            public int ShipLevel { get; set; }
            public ShipClass ShipClass { get; set; }
            public ShipStatus ShipStatus { get; set; }
            public string PrimaryAttack { get; set; }
            public int PrimaryAttackPower { get; set; }
            public string SecondaryAttack { get; set; }
            public int SecondaryAttackPower { get; set; }
            public string UltimateAttack { get; set; }
            public int UltimateAttackPower { get; set; }
            public DateTime ShipWasBuilt { get; set; }
            public DateTime? ShipWasDestroyed { get; set; }

            public List<IFormFile> Files { get; set; }
            public List<ShipImageViewModel> Image { get; set; } = new List<ShipImageViewModel>();

            //db only

            public DateTime Built { get; set; }
            public DateTime Destroyed { get; set; }
    }

}

