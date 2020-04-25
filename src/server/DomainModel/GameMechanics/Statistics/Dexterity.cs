using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Dexterity : IEquatable<Dexterity>
    {
        private const int Minimum = 1;
        public int Value { get; }
        public static Dexterity Initial => new Dexterity(Minimum);

        public Dexterity() =>
            Value = Minimum;

        public Dexterity(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            Value = value;
        }

        public bool Equals(Dexterity other) =>
            Value == other.Value;
    }
}