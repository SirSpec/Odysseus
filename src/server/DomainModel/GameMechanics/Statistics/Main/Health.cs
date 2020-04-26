using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Health : Statistic, IEquatable<Health>
    {
        private const int Minimum = 0;
        private const int HealthPerLevel = 12;
        protected override int BaseValue { get; }

        public Health() =>
            BaseValue = CalculateHealth(Level.One, Strength.Initial);

        public Health(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            BaseValue = value;
        }

        public Health(Level level, Strength strength) =>
            BaseValue = CalculateHealth(level, strength);

        private int CalculateHealth(Level level, Strength strength) =>
            HealthPerLevel * level.Value + strength.Value;

        public bool Equals(Health other) =>
            Value == other.Value;
    }
}