using System;

namespace Odysseus.DomainModel.MapGenerator
{
    public class Room : IEquatable<Room>, IOffsettable<Room>
    {
        public Tile TopLeft { get; }
        public Tile BottomRight { get; }
        public Size Size { get; }

        public Room(Tile topLeft, Tile bottomRight)
        {
            if (topLeft.X > bottomRight.X || topLeft.Y < bottomRight.Y)
            {
                throw new ArgumentException($"Arguments " + 
                    $"{nameof(topLeft)}({topLeft.X}, {topLeft.Y}), " +
                    $"{nameof(bottomRight)}({bottomRight.X}, {bottomRight.Y}) are invalid.");
            }

            (TopLeft, BottomRight) = (topLeft, bottomRight);
            Size = CalculateSize(topLeft, bottomRight);
        }

        public Room(Tile topLeft, Size size)
        {
            TopLeft = topLeft;
            Size = size;
            BottomRight = CalculateBottomRight(topLeft, size);
        }

        public void Deconstruct(out Tile topLeft, out Tile bottomRight, out Size size) =>
            (topLeft, bottomRight, size) = (TopLeft, BottomRight, Size);

        public bool Equals(Room other) => 
            this == other || (TopLeft.Equals(other.TopLeft) && BottomRight.Equals(other.BottomRight));

        public Room OffsetBy(Offset offset) =>
            new Room(TopLeft.OffsetBy(offset), BottomRight.OffsetBy(offset));

        private Size CalculateSize(Tile topLeft, Tile bottomRight)
        {
            var horizontalTiles = Math.Abs(bottomRight.X - topLeft.X) + 1;
            var verticalTiles = Math.Abs(topLeft.Y - bottomRight.Y) + 1;

            return new Size(horizontalTiles, verticalTiles);
        }

        private Tile CalculateBottomRight(Tile topLeft, Size size) =>
            topLeft.OffsetBy(new Offset(size.Width - 1, -(size.Height - 1)));
    }
}
