using System;

namespace Odysseus.Framework.Randomizer
{
    public readonly struct ConstraintRange<TValue> : IEquatable<ConstraintRange<TValue>>
        where TValue : IComparable<TValue>, IEquatable<TValue>
    {
        public TValue Min { get; }
        public TValue Max { get; }

        public ConstraintRange(TValue min, TValue max)
        {
            if (min.CompareTo(max) == 1)
                throw new ArgumentOutOfRangeException($"{nameof(min)}:{min} must be less than or equal to {nameof(max)}:{max}");

            (Min, Max) = (min, max);
        }

        public void Deconstruct(out TValue min, out TValue max) => (min, max) = (Min, Max);
        public bool Equals(ConstraintRange<TValue> other) =>
            Min.Equals(other.Min) && Max.Equals(other.Max);
    }
}
