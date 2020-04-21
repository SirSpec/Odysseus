using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Health
    {
        public int Current { get; }
        public int Total { get; }
        public bool IsDead => Current == 0;

        public Health(int current, int total)
        {
            if (current < 0 || total < 0 || current > total)
                throw new ArgumentException($"{nameof(current)}:{current} or {nameof(total)}:{total} are invalid.");

            (Current, Total) = (current, total);
        }

        public Health Increase(int value)
        {
            var newValue = Current + value >= Total
                ? Total
                : Current + value;

            return new Health(newValue, Total);
        }

        public Health Decrease(int value)
        {
            var newValue = Current - value <= 0
                ? 0
                : Current - value;

            return new Health(newValue, Total);
        }
    }
}
