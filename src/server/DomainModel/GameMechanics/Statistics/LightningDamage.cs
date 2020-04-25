using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class LightningDamage : IStatistic
    {
        private const int Minimum = 0;

        public int Value { get; }

        public LightningDamage() =>
            Value = Minimum;

        public LightningDamage(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");

            Value = value;
        }
    }
}