using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Strength : IStatistic, IEquatable<Strength>
    {
        private const int Minimum = 1;
        public int Value { get; }
        public static Strength Initial => new Strength(Minimum);

        public Strength() =>
            Value = Minimum;

        public Strength(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            Value = value;
        }

        public bool Equals(Strength other) =>
            Value == other.Value;
    }
}