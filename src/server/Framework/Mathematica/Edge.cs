using System;

namespace Odysseus.Framework.Mathematica
{
    public class Edge<TValue> : IEquatable<Edge<TValue>>
        where TValue : notnull
    {
        public Vertex<TValue> Tail { get; }
        public Vertex<TValue> Head { get; }
        public double Weight { get; }

        public Edge(Vertex<TValue> tail, Vertex<TValue> head, double weight) =>
            (Tail, Head, Weight) = (tail, head, weight);

        public bool Equals(Edge<TValue>? other) =>
            this == other ||
            (other is not null && Weight == other.Weight && Tail.Equals(other.Tail) && Head.Equals(other.Head));
    }
}