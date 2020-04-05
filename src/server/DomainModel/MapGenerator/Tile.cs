using System;

namespace Odysseus.DomainModel.MapGenerator
{
    public readonly struct Tile : IEquatable<Tile>, IOffsettable<Tile>
    {
        public int X { get; }
        public int Y { get; }

        public Tile(int x, int y) => (X, Y) = (x, y);
        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);

        public bool Equals(Tile other) => X == other.X && Y == other.Y;

        public Tile OffsetBy(Offset offset) =>
            new Tile(X + offset.X, Y + offset.Y);
    }
}
