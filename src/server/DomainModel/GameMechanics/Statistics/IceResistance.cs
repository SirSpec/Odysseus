using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class IceResistance : IStatistic
    {
        private const int Minimum = 0;
        private const int Maximum = 70;

        public int Value { get; }

        public IceResistance() =>
            Value = Minimum;

        public IceResistance(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            Value = CalculateResistance(value);
        }

        private static int CalculateResistance(int value) =>
            value >= Maximum ? Maximum : value;
    }
}