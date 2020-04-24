using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Level : IEquatable<Level>
    {
        private const int Minimum = 1;
        private const int Maximum = 100;

        public int Value { get; }

        public Level(int level)
        {
            if (level < Minimum || level > Maximum)
                throw new ArgumentException($"{nameof(level)}:{level} is not within the range {Minimum} - {Maximum}.");

            Value = level;
        }

        public bool Equals(Level other) =>
            Value == other.Value;
    }
}