using System;

namespace Odysseus.Framework.Mathematica
{
    public class Vertex<TValue> : IEquatable<Vertex<TValue>>
        where TValue : notnull
    {
        public TValue Value { get; }

        public Vertex(TValue value) => Value = value;

        public bool Equals(Vertex<TValue>? other) => this == other;

        public override string ToString() =>
            Value.ToString() ?? string.Empty;
    }
}
