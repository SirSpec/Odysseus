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


        public bool TryAddVertex(Vertex vertex)
        {
            if (!vertices.Contains(vertex))
            {
                vertices.Add(vertex);
                return true;
            }
            else return false;
        }
        
        public bool TryAddEdge(Edge edge)
        {
            var (first, second) = edge.Vertices;

            if (!Edges.Contains(edge) && Vertices.Contains(first) && Vertices.Contains(second))
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
            var edgesToRemove = Edges.Where(edge => edge.Contains(vertex)).ToList();

            foreach (var edge in edgesToRemove)
            {
                edges.Remove(edge);
            }
        }
    }
}
