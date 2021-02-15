using Microsoft.AspNetCore.SignalR;
using Odysseus.DomainModel.MapGenerator;
using Odysseus.DomainServices.MapGenerator;
using Odysseus.Framework.Randomizer;
using System.Linq;
using System.Threading.Tasks;

namespace Odysseus.Infrastructure.WebApi.Hubs
{
    public class MapHub : Hub
    {
        private readonly ConnectedRoomsDungeonGenerator roomsDungeonGenerator;
        private static Map map;
        private static (int x, int y) enemyPosition = (10, 10);

        public MapHub()
        {
            var roomsGeneratorConfiguration = new AdjacentRoomsGeneratorConfiguration(
                iterations: 10,
                surroundingIterations: 3,
                roomWidthRange: new ConstraintRange<int>(5, 10),
                roomHeightRange: new ConstraintRange<int>(5, 10)
            );

            roomsDungeonGenerator = new ConnectedRoomsDungeonGenerator(
                new AdjacentRoomsGenerator(roomsGeneratorConfiguration),
                new CorridorsGenerator(
                    roomRatioThreshold: 0.4,
                    neighborsNumber: 2
                )
            );
        }

        public async Task SendMap()
        {
            map = roomsDungeonGenerator.Generate();

            await Clients.All.SendAsync("ReceiveMap", map);
            await Clients.All.SendAsync("ReceiveMobsPosition", new { enemyPosition.x, enemyPosition.y });
        }

        public async Task Search(int x, int y)
        {
            var path = new AStarSearch(map.Grid)
                .GetPath(new Tile(enemyPosition.x, enemyPosition.y), new Tile(x, y))
                .ToList();

            if (path.Count > 1) enemyPosition = (path[1].X, path[1].Y);

            await Clients.All.SendAsync("ReceiveMobsPosition", new { enemyPosition.x, enemyPosition.y });
        }
    }
}