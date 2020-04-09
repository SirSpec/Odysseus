using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.MapGenerator
{
    public class CorridorsGenerator
    {
        private readonly double roomRatioThreshold;
        private readonly int neighborsNumber;

        public CorridorsGenerator(double roomRatioThreshold, int neighborsNumber)
        {
            this.roomRatioThreshold = roomRatioThreshold;
            this.neighborsNumber = neighborsNumber;
        }

        public IEnumerable<Corridor> Generate(IEnumerable<Room> rooms)
        {
            var midPointOfMainRooms = rooms.Where(room => CalculateRoomRatio(room) > roomRatioThreshold).Select(CalculateMidpoint);
            var graph = GetGraphOfConnections(midPointOfMainRooms);
            return MapToCorridors(graph);
        }

        private IEnumerable<Corridor> MapToCorridors(Graph<Tile> graph)
        {
            return graph.Vertices.SelectMany(vertex =>
                graph.FindAdjacentOf(vertex)
                    .Select(adjacentVertex => new Corridor(new Vector(adjacentVertex.Value, vertex.Value))));
        }

        private double CalculateRoomRatio(Room room)
        {
            return (double)room.Size.Width / room.Size.Height;
        }

        private Graph<Tile> GetGraphOfConnections(IEnumerable<Tile> midPoints)
        {
            var graph = new Graph<Tile>(midPoints);

            foreach (var seed in graph.Vertices)
            {
                var closesVertices = graph.Vertices
                    .Where(vertex => !vertex.Value.Equals(seed.Value))
                    .OrderBy(vertex => Distance(vertex.Value, seed.Value))
                    .Take(neighborsNumber);

                foreach (var vertex in closesVertices)
                    graph.AddDirectedEdge(seed, vertex, Distance(seed.Value, vertex.Value));
            }

            return new MinimumSpanningTree<Tile>(graph);
        }

        private Tile CalculateMidpoint(Room room)
        {
            var x = (room.TopLeft.X + room.BottomRight.X) / 2;
            var y = (room.TopLeft.Y + room.BottomRight.Y) / 2;
            return new Tile(x, y);
        }

        private double Distance(Tile a, Tile b)
        {
            var deltaX = a.X - b.X;
            var deltaY = a.Y - b.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}