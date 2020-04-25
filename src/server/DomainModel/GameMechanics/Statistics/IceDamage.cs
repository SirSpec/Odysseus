using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class IceDamage : IStatistic
    {
        private const int Minimum = 0;

        public int Value { get; }

        public IceDamage() =>
            Value = Minimum;

        public IceDamage(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");

            Value = value;
        }
    }
}