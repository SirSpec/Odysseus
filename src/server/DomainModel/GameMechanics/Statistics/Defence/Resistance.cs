using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public abstract class Resistance : Statistic
    {
        private const int Minimum = 0;
        private const int Maximum = 70;
        protected override int BaseValue { get; }

        public Resistance() =>
            BaseValue = Minimum;

        public Resistance(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            BaseValue = CalculateResistance(value);
        }

        private static int CalculateResistance(int value) =>
            value >= Maximum ? Maximum : value;
    }
}