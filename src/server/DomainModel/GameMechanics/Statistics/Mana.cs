using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Mana : IStatistic, IEquatable<Mana>
    {
        private const int Minimum = 0;
        private const int ManaPerLevel = 6;

        public int Value { get; }

        public Mana() =>
            Value = CalculateMana(Level.One, Intelligence.Initial);

        public Mana(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            Value = value;
        }

        public Mana(Level level, Intelligence intelligence) =>
            Value = CalculateMana(level, intelligence);

        private int CalculateMana(Level level, Intelligence intelligence) =>
            ManaPerLevel * level.Value + intelligence.Value;

        public bool Equals(Mana other) =>
            Value == other.Value;
    }
}