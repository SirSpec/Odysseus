namespace Odysseus.DomainModel.GameMechanics
{
    public struct Equipment
    {
        public Armor? BodyArmour { get; }
        public Armor? Boots { get; }
        public Armor? Gloves { get; }
        public Armor? Helmet { get; }

        public Item? MainHand { get; }
        public Item? OffHand { get; }

        public void Equip(Item item)
        {
        }
    }
}
