using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Health : IEquatable<Health>
    {
        private const int HealthPerLevel = 12;

        public int Value { get; }

        public Health(Level level, CharacterAttribute strength) =>
            Value = HealthPerLevel * level.Value + strength.Value;

        public bool Equals(Health other) =>
            Value == other.Value;
    }
}
