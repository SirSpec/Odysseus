using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Gold : IEquatable<Gold>
    {
        private const int Minimum = 0;

        public int Value { get; }

        public Gold(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            Value = value;
        }

        public bool Equals(Gold other) =>
            Value == other.Value;
    }
}