using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct CharacterAttribute : IEquatable<CharacterAttribute>
    {
        private const int Minimum = 1;

        public int Value { get; }

        public CharacterAttribute(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            Value = value;
        }

        public bool Equals(CharacterAttribute other) =>
            Value == other.Value;
    }
}
