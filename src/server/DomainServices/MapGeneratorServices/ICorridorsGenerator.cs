using Odysseus.DomainModel.MapGenerator;
using System.Collections.Generic;

namespace Odysseus.DomainServices.MapGenerator
{
    public interface ICorridorsGenerator
    {
        IEnumerable<Corridor> Generate(IEnumerable<Room> rooms);
    }
}