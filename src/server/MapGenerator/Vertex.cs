using System;

namespace Theseus.MapGenerator
{
    public readonly struct Vertex : IEquatable<Vertex>
    {
        public double X { get; }
        public double Y { get; }

        public Vertex(double x, double y) => (X, Y) = (x, y);
        public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);

        public bool Equals(Vertex other) => X == other.X && Y == other.Y;
    }
}
