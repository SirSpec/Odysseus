using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class EnergyPool
    {
        private const int Minimum = 0;

        public int Current { get; private set; }
        public int Total { get; }

        public EnergyPool(int total)
        {
            if (total < Minimum)
                throw new ArgumentException($"{nameof(total)}:{total} cannot be negative.");

            (Current, Total) = (total, total);
        }

        public EnergyPool(int current, int total)
        {
            if (current < Minimum || total < Minimum || current > total)
                throw new ArgumentException($"{nameof(current)}:{current} and {nameof(total)}:{total} are invalid.");

            (Current, Total) = (current, total);
        }

        public void Increase(int value) =>
            Current = Current + value >= Total
                ? Total
                : Current + value;

        public void Decrease(int value) =>
            Current = Current - value <= Minimum
                ? Minimum
                : Current - value;
    }
}