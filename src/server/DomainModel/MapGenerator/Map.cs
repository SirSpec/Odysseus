using System.Collections.Generic;

namespace Odysseus.DomainModel.MapGenerator
{
    public readonly struct Map
    {
        public IEnumerable<Tile> Tiles { get; }
        public Grid Grid { get; }

        public Map(IEnumerable<Tile> tiles)
        {
            Tiles = tiles;

            Grid = new Grid();
            foreach (var tile in tiles)
            {
                Grid.Add(tile);
            }
        }
    }
}
