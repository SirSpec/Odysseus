using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.MapGenerator
{
    public class NonOverlappingRoomsSet
    {
        private readonly IList<Room> rooms;
        public IEnumerable<Room> Rooms => rooms;

        public NonOverlappingRoomsSet() =>
            rooms = new List<Room>();

        public Room this[int index] =>
            rooms[index];

        public bool TryAdd(Room room)
        {
            if (rooms.All(existingRoom => !AreOverlapping(existingRoom, room)))
            {
                rooms.Add(room);
                return true;
            }
            else return false;
        }

        private bool AreOverlapping(Room first, Room second)
        {
            if (first.TopLeft.X > second.BottomRight.X || second.TopLeft.X > first.BottomRight.X) return false;
            if (first.TopLeft.Y < second.BottomRight.Y || second.TopLeft.Y < first.BottomRight.Y) return false;

            return true;
        }
    }
}
