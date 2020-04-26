using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public abstract class Damage : Statistic
    {
        protected override int BaseValue { get; }
        private const int Minimum = 0;

        public Damage() =>
            BaseValue = Minimum;

        public Damage(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");

            BaseValue = value;
        }
    }
}