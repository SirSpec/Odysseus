using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Mana : IEquatable<Health>
    {
        private const int ManaPerLevel = 6;

        public int Value { get; }

        public Mana(Level level, CharacterAttribute intelligence) =>
            Value = ManaPerLevel * level.Value + intelligence.Value;

        public bool Equals(Health other) =>
            Value == other.Value;
    }
}
