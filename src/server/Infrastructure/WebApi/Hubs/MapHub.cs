using Microsoft.AspNetCore.SignalR;
using Odysseus.DomainModel.GameMechanics;
using Odysseus.DomainModel.MapGenerator;
using Odysseus.DomainServices.MapGenerator;
using Odysseus.Framework.Randomizer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odysseus.Infrastructure.WebApi.Hubs
{
    public static class GameContext
    {
        public static PlayerCharacter Hero = new PlayerCharacter("Hero");
        public static PlayerCharacter Enemy = new PlayerCharacter("Enemy");

        public static (int x, int y) EnemyPosition = (10, 10);

        public static Map Map;

        static GameContext()
        {
            var config = new AdjacentRoomsGeneratorConfiguration(10, 3, new ConstraintRange<int>(5, 10), new ConstraintRange<int>(5, 10));
            var generator = new ConnectedRoomsDungeonGenerator(new AdjacentRoomsGenerator(config), new CorridorsGenerator(0.4, 2));
            Map = generator.Generate();
        }
    }

    public class BattleManager
    {
        public void Attack()
        {
            var dmg = GameContext.Hero.Attack();
            GameContext.Enemy.TakeDamage(dmg);
        }

        public async Task Search(int x, int y)
        {
            var searcher = new AStarSearch(GameContext.Map.Grid);
            var path = searcher.GetPath(new Tile(GameContext.EnemyPosition.x, GameContext.EnemyPosition.y), new Tile(x, y)).ToList();
            if (path.Count > 1) GameContext.EnemyPosition = (path[1].X, path[1].Y);
        }

        static bool CanAttack(int x, int y, (int x, int y) mobPosition)
        {
            var h = x == mobPosition.x || x == mobPosition.x - 1 || x == mobPosition.x + 1;
            var v = y == mobPosition.y || y == mobPosition.y - 1 || y == mobPosition.y + 1;

            return h && v;
        }

        static IEnumerable<string> GetMobsToAttack(int x, int y)
        {
            if (CanAttack(x, y, GameContext.EnemyPosition))
                yield return GameContext.Enemy.Name;
        }
    }

    public class MapHub : Hub
    {
        public async Task SendMap()
        {
            await Clients.All.SendAsync("ReceiveMap", GameContext.Map);
            await Clients.All.SendAsync("ReceiveMobsPosition", new { GameContext.EnemyPosition.x, GameContext.EnemyPosition.y });
        }

        public async Task Attack()
        {
            var dmg = GameContext.Hero.Attack();
            GameContext.Enemy.TakeDamage(dmg);
            await Clients.All.SendAsync("ReceiveLog", $"Hero dealt {dmg.Value} damage to Enemy: {GameContext.Enemy.Name}.");

            if (GameContext.Enemy.HealthPool.Current == 0)
                await Clients.All.SendAsync("ReceiveLog", $"Hero killed mob: {GameContext.Enemy.Name}.");
        }

        public async Task Search(int x, int y)
        {
            var searcher = new AStarSearch(GameContext.Map.Grid);
            var path = searcher.GetPath(new Tile(GameContext.EnemyPosition.x, GameContext.EnemyPosition.y), new Tile(x, y)).ToList();
            if (path.Count > 1) GameContext.EnemyPosition = (path[1].X, path[1].Y);

            await Clients.All.SendAsync("ReceiveMobsPosition", new { GameContext.EnemyPosition.x, GameContext.EnemyPosition.y });
            await Clients.All.SendAsync("GetScaned", GetMobsToAttack(x, y));
        }

        static bool CanAttack(int x, int y, (int x, int y) mobPosition)
        {
            var h = x == mobPosition.x || x == mobPosition.x - 1 || x == mobPosition.x + 1;
            var v = y == mobPosition.y || y == mobPosition.y - 1 || y == mobPosition.y + 1;

            return h && v;
        }

        static IEnumerable<string> GetMobsToAttack(int x, int y)
        {
            if (CanAttack(x, y, GameContext.EnemyPosition))
                yield return GameContext.Enemy.Name;
        }
    }
}
