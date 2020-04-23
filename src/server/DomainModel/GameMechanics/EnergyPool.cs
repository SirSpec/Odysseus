using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class EnergyPool
    {
        public int Current { get; private set; }
        public int Total { get; }

        public EnergyPool(int total)
        {
            if (total < 0)
                throw new ArgumentException($"{nameof(total)}:{total} cannot be negative.");

            (Current, Total) = (total, total);
        }

        public EnergyPool(int current, int total)
        {
            if (current < 0 || total < 0 || current > total)
                throw new ArgumentException($"{nameof(current)}:{current} and {nameof(total)}:{total} are invalid.");

            (Current, Total) = (current, total);
        }

        public void Increase(int value) =>
            Current = Current + value >= Total
                ? Total
                : Current + value;

        public void Decrease(int value) =>
            Current = Current - value <= 0
                ? 0
                : Current - value;
    }
}
