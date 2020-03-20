using System.Linq;

namespace Theseus.MapGenerator
{
    public class MinimumSpanningTree : Graph
    {
        public MinimumSpanningTree(Graph graph) : base()
        {
            if (!graph.IsEmpty) CalculateMinimumSpanningTree(graph);
        }

        private void CalculateMinimumSpanningTree(Graph graph)
        {
            TryAddVertex(graph.Vertices.First());
            while (DoesNotHaveTheSameNumberOfVertices(graph))
            {
                var shortestEdge = FindAvailableShortestNonCircularEdge(graph);
                TryAddVertex(shortestEdge.To);
                TryAddEdge(shortestEdge);
            }
        }

        private bool DoesNotHaveTheSameNumberOfVertices(Graph graph)
        {
            return Vertices.Count() != graph.Vertices.Count();
        }

        private Edge FindAvailableShortestNonCircularEdge(Graph graph)
        {
            return graph
                .Edges
                .Where(edge => Vertices.Contains(edge.From) && !Vertices.Contains(edge.To))
                .OrderBy(edge => edge.Weight)
                .First();
        }
    }
}
