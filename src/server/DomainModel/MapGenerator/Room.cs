using System;

namespace Odysseus.DomainModel.MapGenerator
{
    public readonly struct Room : IEquatable<Room>
    {
        public Tile TopLeft { get; }
        public Size Size { get; }

        public Room(Tile topLeft, Size size) => (TopLeft, Size) = (topLeft, size);
        public void Deconstruct(out Tile topLeftLocation, out Size size) => (topLeftLocation, size) = (TopLeft, Size);

        public bool Equals(Room other) => TopLeft.Equals(other.TopLeft) && Size.Equals(other.Size);
    }
}
