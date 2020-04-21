using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Mana
    {
        public int Current { get; }
        public int Total { get; }

        public Mana(int current, int total)
        {
            if (current < 0 || total < 0 || current > total)
                throw new ArgumentException($"{nameof(current)}:{current} or {nameof(total)}:{total} are invalid.");

            (Current, Total) = (current, total);
        }

        public Mana Increase(int value)
        {
            var newValue = Current + value >= Total
                ? Total
                : Current + value;

            return new Mana(newValue, Total);
        }

        public Mana Decrease(int value)
        {
            var newValue = Current - value <= 0
                ? 0
                : Current - value;

            return new Mana(newValue, Total);
        }
    }
}
