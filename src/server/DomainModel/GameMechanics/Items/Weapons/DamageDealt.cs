namespace Odysseus.DomainModel.GameMechanics.Items.Weapons
{
    public readonly struct DamageDealt
    {
        public int Value { get; }
        public DamageType Type { get; }

        public DamageDealt(int value, DamageType type) =>
            (Value, Type) = (value, type);
    }
}