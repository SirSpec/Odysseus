using System.Collections.Generic;

namespace Odysseus.DomainModel.MapGenerator
{
    public interface IRoomsGenerator
    {
        IEnumerable<Room> Generate();
    }
}