using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class MeleeDamage : IStatistic
    {
        private const int Minimum = 0;

        public int Value { get; }

        public MeleeDamage() =>
            Value = Minimum;

        public MeleeDamage(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");

            Value = value;
        }
    }
}