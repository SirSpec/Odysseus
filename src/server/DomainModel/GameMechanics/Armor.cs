using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Armor : IEquatable<Armor>
    {
        private const int Minimum = 0;

        public int Value { get; }

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