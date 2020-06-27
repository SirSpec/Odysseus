using Microsoft.AspNetCore.SignalR;
using Odysseus.DomainModel.GameMechanics;
using Odysseus.DomainModel.GameMechanics.Items;
using Odysseus.DomainModel.GameMechanics.Items.Weapons;
using Odysseus.DomainModel.MapGenerator;
using Odysseus.DomainServices.MapGenerator;
using Odysseus.Framework.Randomizer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odysseus.Infrastructure.WebApi.Hubs
{
    public class MapHub : Hub
    {
        static List<PlayerCharacter> Mobs = new List<PlayerCharacter>
        {
            new PlayerCharacter("Mob 1"),
            new PlayerCharacter("Mob 2"),
            new PlayerCharacter("Mob 3"),
        };

        static List<dynamic> mobsPosition;

        static PlayerCharacter Hero = new PlayerCharacter("Hero");

        static Map Map;

        public async Task SendMap()
        {
            var config = new AdjacentRoomsGeneratorConfiguration(10, 3, new ConstraintRange<int>(5, 10), new ConstraintRange<int>(5, 10));
            var generator = new ConnectedRoomsDungeonGenerator(new AdjacentRoomsGenerator(config), new CorridorsGenerator(0.4, 2));
            Map = generator.Generate();

            mobsPosition = new List<dynamic>
        {
            new { x =10, y = 10 },
            new { x =14, y = 8 },
            new { x =3, y = 5 },
        };

            await Clients.All.SendAsync("ReceiveMap", Map);
            await Clients.All.SendAsync("ReceiveMobsPosition", mobsPosition);
        }

        public async Task SendMobs()
        {
            await Clients.All.SendAsync("ReceiveMobsPosition", mobsPosition);
        }

        public async Task Scan(int x, int y)
        {
            await Clients.All.SendAsync("GetScaned", GetMobsToAttack(x, y));
        }

        public async Task Attack(string name)
        {
            var mob = Mobs.FirstOrDefault(p => p.Name == name);

            if (mob != null)
            {
                var dmg = Hero.Attack();
                mob.TakeDamage(dmg);
                await Clients.All.SendAsync("ReceiveLog", $"Hero dealt {dmg.Value} damage to mob: {mob.Name}.");
            }

            if (mob.HealthPool.Current == 0)
            {
                Mobs.Remove(mob);
                await Clients.All.SendAsync("ReceiveLog", $"Hero killed mob: {mob.Name}.");
            }

            await Clients.All.SendAsync("ReceiveMobs", Mobs.Select(m => m.Name));
            await Clients.All.SendAsync("ReceiveMobsPosition", mobsPosition);
        }

        public async Task Search(int x, int y)
        {
            for (int i = 0; i < mobsPosition.Count; i++)
            {
                var searcher = new AStarSearch(Map.Grid);
                var path = searcher.GetPath(new Tile(mobsPosition[i].x, mobsPosition[i].y), new Tile(x, y)).ToList();
                if(path.Count > 1)
                    mobsPosition[i] = new { x = path[1].X, y = path[1].Y };
            }

            await Clients.All.SendAsync("ReceiveMobsPosition", mobsPosition);
            await Clients.All.SendAsync("GetScaned", GetMobsToAttack(x, y));
        }

        static bool CanAttack(int x, int y, dynamic mobPosition)
        {
            var h = x == mobPosition.x || x == mobPosition.x - 1 || x == mobPosition.x + 1;
            var v = y == mobPosition.y || y == mobPosition.y - 1 || y == mobPosition.y + 1;

            return h && v;
        }
        
        static IEnumerable<string> GetMobsToAttack(int x, int y)
        {
            for (int i = 0; i < mobsPosition.Count; i++)
            {
                if (CanAttack(x, y, mobsPosition[i]))
                    yield return "Mob " + (i+1);
            }
        }
    }
}
