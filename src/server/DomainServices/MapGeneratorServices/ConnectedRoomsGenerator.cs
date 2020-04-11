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

            var tiles = rooms.SelectMany(GetTile).Concat(corridors.SelectMany(GetTile));

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

        public IEnumerable<Tile> GetTile(Corridor corridor)
        {
            var (start, end) = corridor.Vector;

            yield return start;
            yield return end;

            if (start.X <= end.X)
                for (int x = start.X; x < end.X; x++)
                    yield return new Tile(x, start.Y);
            else
                for (int x = end.X; x < start.X; x++)
                    yield return new Tile(x, start.Y);

            if (start.Y <= end.Y)
                for (int y = start.Y; y < end.Y; y++)
                    yield return new Tile(start.X, y);
            else
                for (int y = end.Y; y < start.Y; y++)
                    yield return new Tile(start.X, y);
        }
    }
}
