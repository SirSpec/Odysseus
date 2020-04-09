using System;

namespace Odysseus.DomainModel.MapGenerator
{
    public readonly struct Offset : IEquatable<Offset>
    {
        public int X { get; }
        public int Y { get; }

        public Offset(int x, int y) => (X, Y) = (x, y);

        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        public bool Equals(Offset other) => X == other.X && Y == other.Y;

        public Offset Then(Offset offset) => new Offset(X + offset.X, Y + offset.Y);

        public static Offset LeftBy(int offset) => new Offset(-offset, 0);
        public static Offset RightBy(int offset) => new Offset(offset, 0);
        public static Offset TopBy(int offset) => new Offset(0, offset);
        public static Offset BottomBy(int offset) => new Offset(0, -offset);
    }
}
