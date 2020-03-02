using System;

namespace Theseus.MapGenerator
{
    public readonly struct Corridor : IEquatable<Corridor>
    {
        public Vector Vector { get; }

        public Corridor(Vector vector) => (Vector) = (vector);
        public bool Equals(Corridor other) => Vector.Equals(other.Vector);
    }
}
