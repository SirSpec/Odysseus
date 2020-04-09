using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.MapGenerator
{
    public class NonOverlappingRoomsSet
    {
        private readonly IList<Room> rooms;
        public IEnumerable<Room> Rooms => rooms;

        public NonOverlappingRoomsSet()
        {
            rooms = new List<Room>();
        }

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

        private bool AreOverlapping(Room a, Room b)
        {
            if (a.TopLeft.X > b.BottomRight.X || b.TopLeft.X > a.BottomRight.X) return false;
            if (a.TopLeft.Y < b.BottomRight.Y || b.TopLeft.Y < a.BottomRight.Y) return false;

            return true;
        }
    }
}
