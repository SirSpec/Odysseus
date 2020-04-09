using System.Collections.Generic;

namespace Odysseus.DomainModel.MapGenerator
{
    public readonly struct Map
    {
        public IEnumerable<Tile> Tiles { get; }
        
        public Map(IEnumerable<Tile> tiles)
        {
            Tiles = tiles;
        }
    }
}
