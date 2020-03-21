using System;
using System.Linq;

namespace Theseus.MapGenerator
{
    // https://en.wikipedia.org/wiki/Kruskal%27s_algorithm
    public class MinimumSpanningTree<TValue> : Graph<TValue>
        where TValue : notnull
    {
        public MinimumSpanningTree(Graph<TValue> graph) : base()
        {
            CalculateMinimumSpanningTree(graph);
        }

        private void CalculateMinimumSpanningTree(Graph<TValue> graph)
        {
            var disjointSet = new DisjointSet<Vertex<TValue>>(graph.Vertices);

            foreach (var shortestEdge in graph.Edges.OrderBy(edge => edge.Weight))
            {
                if (graph.ContainsSymmetric(shortestEdge) ||!disjointSet.HaveTheSameRoot(shortestEdge.Tail, shortestEdge.Head))
                {
                    CreateNewConnection(shortestEdge);
                    disjointSet.Union(shortestEdge.Tail, shortestEdge.Head);
                }
            }
        }

        private void CreateNewConnection(Edge<TValue> shortestEdge)
        {
            if (!Vertices.Contains(shortestEdge.Head)) AddVertex(shortestEdge.Head);
            if (!Vertices.Contains(shortestEdge.Tail)) AddVertex(shortestEdge.Tail);

            AddEdge(shortestEdge);
        }
    }
}
