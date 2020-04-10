using Odysseus.DomainModel.MapGenerator;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainServices.MapGenerator
{
    public class ConnectedRoomsDungeonGenerator : IMapGenerator
    {
        private readonly IRoomsGenerator roomsGenerator;
        private readonly ICorridorsGenerator corridorsGenerator;

        public ConnectedRoomsDungeonGenerator(
            IRoomsGenerator roomsGenerator,
            ICorridorsGenerator corridorsGenerator)
        {
            this.roomsGenerator = roomsGenerator;
            this.corridorsGenerator = corridorsGenerator;
        }

        public Map Generate()
        {
            var rooms = roomsGenerator.Generate();
            var corridors = corridorsGenerator.Generate(rooms);

            var tiles = rooms.SelectMany(GetTile);

            return new Map(tiles);
        }

        public IEnumerable<Tile> GetTile(Room room)
        {
            for (int x = room.TopLeft.X; x <= room.BottomRight.X; x++)
            {
                for (int y = room.BottomRight.Y; y <= room.TopLeft.Y; y++)
                {
                    yield return new Tile(x, y);
                }
            }
        }
    }
}
