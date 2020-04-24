using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Resistance
    {
        private const int Minimum = 0;
        private const int Maximum = 70;

        public int UncappedValue { get; }
        public int Value { get; }

        public Resistance(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            UncappedValue = value;
            Value = CalculateResistance(value);
        }

        private static int CalculateResistance(int value) =>
            value >= Maximum ? Maximum : value;
    }
}
