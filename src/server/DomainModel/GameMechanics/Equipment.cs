namespace Odysseus.DomainModel.GameMechanics
{
    public class Equipment
    {
        public Armor? BodyArmour { get; set; }
        public Armor? Boots { get; set; }
        public Armor? Gloves { get; set; }
        public Armor? Helmet { get; set; }

        public Weapon? MainHand { get; set; }
        public Item? OffHand { get; set; }

        public double Weight =>
            BodyArmour?.Weight ?? 0.0 +
            Boots?.Weight ?? 0.0 +
            Gloves?.Weight ?? 0.0 +
            Helmet?.Weight ?? 0.0 +
            MainHand?.Weight ?? 0.0 +
            OffHand?.Weight ?? 0.0;

        public Damage[] Damage => (MainHand, OffHand) switch
        {
            (Weapon mainHand, Weapon offHand) => new[] { mainHand.Damage, offHand.Damage },
            (Weapon mainHand, _) => new[] { mainHand.Damage },
            _ => new Damage[] { }
        };

        public int Armor =>
            BodyArmour?.Value ?? 0 +
            Boots?.Value ?? 0 +
            Gloves?.Value ?? 0 +
            Helmet?.Value ?? 0 +
            ((OffHand is Armor offHand) ? offHand.Value : 0);
    }
}