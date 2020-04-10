using System.Collections.Generic;

namespace Odysseus.DomainModel.MapGenerator
{
    public interface ICorridorsGenerator
    {
        IEnumerable<Corridor> Generate(IEnumerable<Room> rooms);
    }
}