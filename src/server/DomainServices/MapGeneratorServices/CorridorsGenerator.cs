using Odysseus.DomainModel.MapGenerator;
using Odysseus.Framework.Mathematica;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainServices.MapGenerator
{
    public class CorridorsGenerator : ICorridorsGenerator
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
            var midPointOfMainRooms = rooms
                .Where(room => RoomRatio(room) > roomRatioThreshold)
                .Select(Midpoint);
            var graph = GetGraphOfConnections(midPointOfMainRooms);

            return MapToCorridors(graph);
        }

        private IEnumerable<Corridor> MapToCorridors(Graph<Tile> graph) =>
            graph.Vertices.SelectMany(vertex =>
                graph.FindAdjacentOf(vertex)
                    .Select(adjacentVertex => new Corridor(new Vector(adjacentVertex.Value, vertex.Value))));

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

        private double RoomRatio(Room room) =>
            room.Size.Width <= room.Size.Height
                ? (double)room.Size.Width / room.Size.Height
                : (double)room.Size.Height / room.Size.Width;

        private Tile Midpoint(Room room)
        {
            var midPoint = MathExtensions.Midpoint(
                (room.TopLeft.X, room.TopLeft.Y),
                (room.BottomRight.X, room.BottomRight.Y));

            return new Tile((int)midPoint.X, (int)midPoint.Y);
        }

        private double Distance(Tile a, Tile b) =>
            MathExtensions.Distance((a.X, a.Y), (b.X, b.Y));
    }
}