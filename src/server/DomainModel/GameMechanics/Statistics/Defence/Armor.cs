using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Armor : Statistic, IEquatable<Armor>
    {
        private const int Minimum = 0;
        protected override int BaseValue { get; }

        public Armor() =>
            BaseValue = Minimum;

        public Armor(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");

            BaseValue = value;
        }

        public Armor Scale(Strength strength) =>
            new Armor(Value + strength.Value);

        public bool Equals(Armor other) =>
            Value == other.Value;
    }
}