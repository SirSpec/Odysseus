using System;

namespace Odysseus.DomainModel.MapGenerator
{
    public readonly struct Vector : IEquatable<Vector>
    {
        public Tile Start { get; }
        public Tile End { get; }

        public Vector(Tile start, Tile end) =>
            (Start, End) = (start, end);

        public void Deconstruct(out Tile start, out Tile end) =>
            (start, end) = (Start, End);

        public bool Equals(Vector other) =>
            Start.Equals(other.Start) && End.Equals(other.End);
    }
}
