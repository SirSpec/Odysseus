using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public abstract class Attribute : Statistic, IEquatable<Attribute>
    {
        protected const int Minimum = 1;
        protected override int BaseValue { get; }

        public Attribute() =>
            BaseValue = Minimum;

        public Attribute(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            BaseValue = value;
        }

        public abstract Attribute Increase();

        public bool Equals(Attribute other) =>
            Value == other.Value;
    }
}