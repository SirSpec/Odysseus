using Odysseus.DomainModel.GameMechanics.Items.Weapons;

namespace Odysseus.DomainModel.GameMechanics.Spells.Effects
{
    public readonly struct OffensiveInstant : IInstant<DamageDealt>
    {
        public string Name { get; }
        public DamageDealt Value { get; }

        public OffensiveInstant(string name, DamageDealt damage) =>
            (Name, Value) = (name, damage);
    }
}