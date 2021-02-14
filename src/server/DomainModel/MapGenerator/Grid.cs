using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.MapGenerator
{
    public class Grid
    {
        private readonly IEnumerable<Offset> directions = new List<Offset>
        {
            Offset.LeftBy(1),
            Offset.RightBy(1),
            Offset.BottomBy(1),
            Offset.TopBy(1)
        };

        private readonly ICollection<Tile> tiles;

        public IEnumerable<Tile> Tiles => tiles;
        public int MovementCost => 1;

        public Grid() =>
            tiles = new List<Tile>();

        public void Add(Tile tile)
        {
            if (tiles.Contains(tile) is false)
                tiles.Add(tile);
            else throw new InvalidOperationException($"{nameof(tile)}:{tile} already exists.");
        }

        public IEnumerable<Tile> Neighbors(Tile tile)
        {
            foreach (var direction in directions)
            {
                var offsetted = tile.OffsetBy(direction);

                if (Tiles.Contains(offsetted))
                    yield return Tiles.Single(neighbor => neighbor.Equals(offsetted));
            }
        }
    }
}