using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Health : IStatistic, IEquatable<Health>
    {
        private const int Minimum = 0;
        private const int HealthPerLevel = 12;

        public int Value { get; }

        public Health() =>
            Value = CalculateHealth(Level.One, Strength.Initial);

        public Health(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            Value = value;
        }

        public Health(Level level, Strength strength) =>
            Value = CalculateHealth(level, strength);

        private int CalculateHealth(Level level, Strength strength) =>
            HealthPerLevel * level.Value + strength.Value;

        public bool Equals(Health other) =>
            Value == other.Value;
    }
}