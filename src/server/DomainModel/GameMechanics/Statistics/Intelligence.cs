using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Intelligence : IEquatable<Intelligence>
    {
        private const int Minimum = 1;
        public int Value { get; }
        public static Intelligence Initial => new Intelligence(Minimum);

        public Intelligence() =>
            Value = Minimum;

        public Intelligence(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            Value = value;
        }

        public bool Equals(Intelligence other) =>
            Value == other.Value;
    }
}