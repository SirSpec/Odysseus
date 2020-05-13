﻿using System;

namespace Odysseus.DomainModel.GameMechanics.Inventory
{
    public readonly struct Weight : IEquatable<Weight>
    {
        private const int Minimum = 0;
        public int Value { get; }
        public static Weight Zero => new Weight(Minimum);

        public Weight(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            Value = value;
        }

        public static Weight operator +(Weight left, Weight right) =>
            new Weight(left.Value + right.Value);

        public static bool operator <=(Weight left, Weight right) =>
            left.Value <= right.Value;

        public static bool operator >=(Weight left, Weight right) =>
            left.Value >= right.Value;

        public bool Equals(Weight other) =>
            Value == other.Value;
    }
}