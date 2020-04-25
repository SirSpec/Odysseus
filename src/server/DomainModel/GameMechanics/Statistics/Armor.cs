using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Armor : IStatistic, IEquatable<Armor>
    {
        private const int Minimum = 0;

        public int Value { get; }

        public Armor() =>
            Value = Minimum;

        public Armor(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");

            Value = value;
        }

        public bool Equals(Armor other) =>
            Value == other.Value;
    }
}