namespace Odysseus.DomainModel.GameMechanics
{
    public class Equipment
    {
        public BodyArmor? BodyArmour { get; set; }
        public BodyArmor? Boots { get; set; }
        public BodyArmor? Gloves { get; set; }
        public BodyArmor? Helmet { get; set; }

        public Weapon? MainHand { get; set; }
        public IItem? OffHand { get; set; }

        public double Weight =>
            BodyArmour?.Weight ?? 0.0 +
            Boots?.Weight ?? 0.0 +
            Gloves?.Weight ?? 0.0 +
            Helmet?.Weight ?? 0.0 +
            MainHand?.Weight ?? 0.0 +
            OffHand?.Weight ?? 0.0;

        public MeleeDamage[] Damage => (MainHand, OffHand) switch
        {
            (Weapon mainHand, Weapon offHand) => new[] { mainHand.Damage, offHand.Damage },
            (Weapon mainHand, _) => new[] { mainHand.Damage },
            _ => new MeleeDamage[] { }
        };

        public int Armor =>
            BodyArmour?.Armor.Value ?? 0 +
            Boots?.Armor.Value ?? 0 +
            Gloves?.Armor.Value ?? 0 +
            Helmet?.Armor.Value ?? 0 +
            ((OffHand is BodyArmor offHand) ? offHand.Armor.Value : 0);
    }
}