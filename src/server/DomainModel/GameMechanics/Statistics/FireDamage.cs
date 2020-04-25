using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class FireDamage : IStatistic
    {
        private const int Minimum = 0;

        public int Value { get; }

        public FireDamage() =>
            Value = Minimum;

        public FireDamage(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");

            Value = value;
        }
    }
}