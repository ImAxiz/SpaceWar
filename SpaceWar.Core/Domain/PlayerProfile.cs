namespace GalacticTitans.Core.Domain
{
    public enum ProfileStatus
    {
        Active, Abandoned, Deactivated, Locked, Banned, ManualReviewNecessary
    }
    public class PlayerProfile
    {
        public Guid ID { get; set; }
        public Guid ApplicationUserID { get; set; } // 1-1
        public string ScreenName { get; set; }
        public int Credits { get; set; }
        public int MetalResource { get; set; }
        public List<ShipOwnership> MyTitans { get; set; }
        public int Victories { get; set; }
        public int MyProperty { get; set; }
        public string? MyGalaxy { get; set; } //do not use this property yet, this needs to become a solarsystem object attached to the player, this is not a system the admin makes, in the future, it will be part of feature for creating users own solar system
        public ProfileStatus CurrentStatus { get; set; }

        public bool ProfileType { get; set; } //true, admin, false, player

        //dbonly
        public DateTime ProfileCreatedAt { get; set; }
        public DateTime ProfileModifiedAt { get; set; }
        public DateTime ProfileAttributedToAnAccountUserAt { get; set; }
        public DateTime ProfileStatusLastChangedAt { get; set; }

    }
}