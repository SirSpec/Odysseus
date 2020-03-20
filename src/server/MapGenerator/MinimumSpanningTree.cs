using System.Linq;

namespace Theseus.MapGenerator
{
    // https://en.wikipedia.org/wiki/Prim%27s_algorithm
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

        private bool DoesNotHaveTheSameNumberOfVertices(Graph graph) =>
            Vertices.Count() != graph.Vertices.Count();

        private Edge FindAvailableShortestNonCircularEdge(Graph graph) =>
            graph.Edges
                .Where(IsAvailableAndNonCircular)
                .OrderBy(edge => edge.Weight)
                .First();

        private bool IsAvailableAndNonCircular(Edge edge) =>
            Vertices.Contains(edge.From) && !Vertices.Contains(edge.To);
    }
}
