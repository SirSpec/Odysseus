using Odysseus.DomainModel.MapGenerator;
using System.Collections.Generic;

namespace Odysseus.DomainServices.MapGenerator
{
    public interface IRoomsGenerator
    {
        IEnumerable<Room> Generate();
    }
}