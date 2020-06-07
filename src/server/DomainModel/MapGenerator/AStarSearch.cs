using Odysseus.Framework.Mathematica;
using System;
using System.Collections.Generic;

namespace Odysseus.DomainModel.MapGenerator
{
    // https://en.wikipedia.org/wiki/A*_search_algorithm
    public class AStarSearch
    {
        private readonly Grid grid;

        public AStarSearch(Grid grid) =>
            this.grid = grid;

        public IEnumerable<Tile> GetPath(Tile start, Tile goal)
        {
            var cameFrom = new Dictionary<Tile, Tile>();
            var costSoFar = new Dictionary<Tile, double>();
            var frontier = new BinaryHeap<double, Tile>();

            frontier.Insert(0, start);
            cameFrom[start] = start;
            costSoFar[start] = 0;

            while (!frontier.IsEmpty)
            {
                var current = frontier.ExtractMinimum().Value;

                if (current.Equals(goal)) break;

                foreach (var next in grid.Neighbors(current))
                {
                    double newCost = costSoFar[current] + grid.MovementCost;
                    if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                    {
                        costSoFar[next] = newCost;
                        double priority = newCost + Heuristic(next, goal);
                        frontier.Insert(priority, next);
                        cameFrom[next] = current;
                    }
                }
            }

            return ReconstructPath(cameFrom, start, goal);
        }

        private IEnumerable<Tile> ReconstructPath(Dictionary<Tile, Tile> cameFrom, Tile start, Tile goal)
        {
            var current = goal;
            var path = new List<Tile>();

            while (!current.Equals(start))
            {
                path.Add(current);
                current = cameFrom[current];
            }

            path.Add(start);
            path.Reverse();

            return path;
        }

        // https://en.wikipedia.org/wiki/Taxicab_geometry
        private double Heuristic(Tile from, Tile to) =>
            Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
    }
}