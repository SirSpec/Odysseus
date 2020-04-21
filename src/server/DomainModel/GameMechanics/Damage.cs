namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Damage
    {
        public int Value { get; }
        public DamageType Type { get; }

        public Damage(int value, DamageType type) =>
            (Value, Type) = (value, type);
    }
}
