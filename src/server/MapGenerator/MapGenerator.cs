using System;
using System.Collections.Generic;
using System.Text;

namespace Theseus.MapGenerator
{
    public class MapGenerator
    {
        private readonly Random random = new Random();

        public void Gen()
        {
            var rooms = new List<Room> { new Room(new Tile(), GetRandomSize()) };

            for (int i = 0; rooms.Count < 10; i++)
            {
                var seedRoom = rooms[i];
                for (int j = 0; j < 3; j++)
                {
                    var size = GetRandomSize(); // todo: 4 walls
                    var newRoom = new Room(new Tile(seedRoom.TopLeft.X - size.Width, seedRoom.TopLeft.Y), size);
                    if (RoomDoesNotIntersect(newRoom)) rooms.Add(newRoom);
                }
            }
        }

        private bool RoomDoesNotIntersect(Room newRoom)
        {
            throw new NotImplementedException();
        }

        Size GetRandomSize() => new Size(random.Next(), random.Next());
    }
}
