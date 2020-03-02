using System;

namespace Theseus.MapGenerator
{
    public readonly struct Room : IEquatable<Room>
    {
        public Tile TopLeftLocation { get; }
        public Size Size { get; }

        public Room(Tile topLeftLocation, Size size) => (TopLeftLocation, Size) = (topLeftLocation, size);
        public void Deconstruct(out Tile topLeftLocation, out Size size) => (topLeftLocation, size) = (TopLeftLocation, Size);

        public bool Equals(Room other) => TopLeftLocation.Equals(other.TopLeftLocation) && Size.Equals(other.Size);
    }
}
