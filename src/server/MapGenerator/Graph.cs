using System;
using System.Collections.Generic;
using System.Linq;

namespace Theseus.MapGenerator
{
    public class Graph
    {
        private readonly IList<Vertex> vertices = new List<Vertex>();
        private readonly IList<Edge> edges = new List<Edge>();

        public IEnumerable<Vertex> Vertices => vertices;
        public IEnumerable<Edge> Edges => edges;

        public bool IsEmpty => !Vertices.Any();

        public IEnumerable<Vertex> FindAdjacentOf(Vertex vertex) =>
            Edges.Where(edge => edge.From.Equals(vertex)).Select(edge => edge.To);

        public bool Contains(Vertex vertex) =>
            Vertices.Contains(vertex);

        public bool TryAddVertex(Vertex vertex)
        {
            if (!vertices.Contains(vertex))
            {
                vertices.Add(vertex);
                return true;
            }
            else return false;
        }

        public bool TryAddDirectedEdge(Vertex from, Vertex to, double weight)
        {
            var newEdge = new Edge(from, to, weight);
            return TryAddEdge(newEdge);
        }

        public bool TryAddUndirectedEdge(Vertex a, Vertex b, double weight)
        {
            var newEdge1 = new Edge(a, b, weight);
            var newEdge2 = new Edge(b, a, weight);

            return TryAddEdge(newEdge1) && TryAddEdge(newEdge2);
        }

        public bool TryAddEdge(Edge edge)
        {
            if (!Edges.Contains(edge) && Vertices.Contains(edge.From) && Vertices.Contains(edge.To))
            {
                edges.Add(edge);
                return true;
            }
            else return false;
        }

        public bool TryRemoveEdge(Edge edge)
        {
            if (Edges.Contains(edge))
            {
                edges.Remove(edge);
                return true;
            }
            else return false;
        }

        public bool TryRemoveVertex(Vertex vertex)
        {
            if (Vertices.Contains(vertex))
            {
                RemoveEdgesThatContain(vertex);
                vertices.Remove(vertex);
                return true;
            }
            else return false;
        }

        private void RemoveEdgesThatContain(Vertex vertex)
        {
            var edgesToRemove = Edges.Where(edge => edge.From.Equals(vertex) || edge.To.Equals(vertex)).ToList();
            foreach (var edge in edgesToRemove)
            {
                edges.Remove(edge);
            }
        }
    }
}
