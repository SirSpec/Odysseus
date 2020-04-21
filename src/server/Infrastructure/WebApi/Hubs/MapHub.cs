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
    public class MapHub : Hub
    {
        static List<PlayerCharacter> Mobs = new List<PlayerCharacter>
        {
            new PlayerCharacter("1"),
            new PlayerCharacter("2"),
            new PlayerCharacter("3"),
        };

        static PlayerCharacter Hero = new PlayerCharacter("Hero");

        public async Task SendMap()
        {
            var config = new AdjacentRoomsGeneratorConfiguration(10, 3, new ConstraintRange<int>(5, 10), new ConstraintRange<int>(5, 10));
            var generator = new ConnectedRoomsDungeonGenerator(new AdjacentRoomsGenerator(config), new CorridorsGenerator(0.4, 2));

            await Clients.All.SendAsync("ReceiveMap", generator.Generate());
            await Clients.All.SendAsync("ReceiveMobs", Mobs.Select(m => m.Name));
        }

        public async Task Attack(string name)
        {
            var mob = Mobs.FirstOrDefault(p => p.Name == name);

            if (mob != null)
            {
                var dmg = Hero.Attack();
                mob.ReceiveDamage(dmg);
                await Clients.All.SendAsync("ReceiveLog", $"Hero dealt {dmg.Value} damage to mob: {mob.Name}.");
            }

            if (mob.Health.IsDead)
            {
                Mobs.Remove(mob);
                await Clients.All.SendAsync("ReceiveLog", $"Hero killed mob: {mob.Name}.");
            }

            await Clients.All.SendAsync("ReceiveMobs", Mobs.Select(m => m.Name));
        }
    }
}
