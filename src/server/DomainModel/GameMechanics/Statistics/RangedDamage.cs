using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class RangedDamage : IStatistic
    {
        private const int Minimum = 0;

        public int Value { get; }

        public RangedDamage() =>
            Value = Minimum;

        public RangedDamage(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");

            Value = value;
        }
    }
}