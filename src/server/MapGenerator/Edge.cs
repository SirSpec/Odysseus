using System;

namespace Theseus.MapGenerator
{
    public readonly struct Edge : IEquatable<Edge>
    {
        public (Vertex first, Vertex second) Vertices { get; }
        public double Weight { get; }

        public Edge((Vertex first, Vertex second) vertices, double weight) =>
            (Vertices, Weight) = (vertices, weight);

        public void Deconstruct(out (Vertex first, Vertex second) vertices, out double weight) =>
            (vertices, weight) = (Vertices, Weight);

        public bool Equals(Edge other)
        {
            var (first, second) = Vertices;
            var (otherFirst, otherSecond) = other.Vertices;

            return Weight == other.Weight &&
                (first.Equals(otherFirst) || first.Equals(otherSecond)) &&
                (second.Equals(otherFirst) || second.Equals(otherSecond));
        }

        public bool Contains(Vertex vertex) =>
            Vertices.first.Equals(vertex) || Vertices.second.Equals(vertex);
    }
}
