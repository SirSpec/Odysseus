using System;

namespace Theseus.MapGenerator
{
    public readonly struct Edge : IEquatable<Edge>
    {
        public Vertex From { get; }
        public Vertex To { get; }
        public double Weight { get; }

        public Edge(Vertex from, Vertex to, double weight) =>
            (From, To, Weight) = (from, to, weight);

        public bool Equals(Edge other) =>
            Weight == other.Weight && From.Equals(other.From) && To.Equals(other.To);
    }
}
