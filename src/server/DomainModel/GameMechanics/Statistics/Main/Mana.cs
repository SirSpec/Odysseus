using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Mana : Statistic, IEquatable<Mana>
    {
        private const int Minimum = 0;
        private const int ManaPerLevel = 6;
        protected override int BaseValue { get; }

        public Mana() =>
            BaseValue = CalculateMana(Level.One, Intelligence.Initial);

        public Mana(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            BaseValue = value;
        }

        public Mana(Level level, Intelligence intelligence) =>
            BaseValue = CalculateMana(level, intelligence);

        private int CalculateMana(Level level, Intelligence intelligence) =>
            ManaPerLevel * level.Value + intelligence.Value;

        public bool Equals(Mana other) =>
            BaseValue == other.BaseValue;
    }
}