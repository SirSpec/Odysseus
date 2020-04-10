using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.Framework.Mathematica
{
    public class Graph<TValue> where TValue : notnull
    {
        private readonly IList<Vertex<TValue>> vertices;
        private readonly IList<Edge<TValue>> edges = new List<Edge<TValue>>();

        public IEnumerable<Vertex<TValue>> Vertices => vertices;
        public IEnumerable<Edge<TValue>> Edges => edges;

        public Graph()
        {
            vertices = new List<Vertex<TValue>>();
        }

        public Graph(IEnumerable<TValue> values)
        {
            vertices = values.Select(value => new Vertex<TValue>(value)).ToList();
        }

        public bool IsEmpty => !Vertices.Any();

        public IEnumerable<Vertex<TValue>> FindAdjacentOf(Vertex<TValue> vertex) =>
            Edges.Where(edge => edge.Tail.Equals(vertex)).Select(edge => edge.Head);

        public bool Contains(Vertex<TValue> vertex) =>
            Vertices.Contains(vertex);

        public bool ContainsSymmetric(Edge<TValue> edge) =>
            Edges.Any(existingEdge => AreSymmetric(existingEdge, edge));


        public void AddVertex(Vertex<TValue> vertex)
        {
            if (!vertices.Contains(vertex)) vertices.Add(vertex);
            else throw new InvalidOperationException($"Vertex{{{vertex}}} already exists.");
        }

        public void AddDirectedEdge(Vertex<TValue> tail, Vertex<TValue> head, double weight) =>
            AddEdge(new Edge<TValue>(tail, head, weight));

        public void AddUndirectedEdge(Vertex<TValue> a, Vertex<TValue> b, double weight)
        {
            AddEdge(new Edge<TValue>(a, b, weight));
            AddEdge(new Edge<TValue>(b, a, weight));
        }

        public void AddEdge(Edge<TValue> edge)
        {
            if (!Edges.Contains(edge) && Vertices.Contains(edge.Head) && Vertices.Contains(edge.Tail))
                edges.Add(edge);
            else throw new InvalidOperationException($"Edge{{{edge.Head} - {edge.Weight} -> {edge.Tail}}} already exists.");
        }

        public void RemoveEdge(Edge<TValue> edge)
        {
            if (Edges.Contains(edge)) edges.Remove(edge);
            else throw new InvalidOperationException($"Edge{{{edge.Head} - {edge.Weight} -> {edge.Tail}}} does not exist.");
        }

        public void RemoveVertex(Vertex<TValue> vertex)
        {
            if (Vertices.Contains(vertex))
            {
                RemoveEdgesThatContain(vertex);
                vertices.Remove(vertex);
            }
            else throw new InvalidOperationException($"Vertex{{{vertex}}} does not exist.");
        }

        private void RemoveEdgesThatContain(Vertex<TValue> vertex)
        {
            var edgesToRemove = Edges.Where(edge => edge.Head.Equals(vertex) || edge.Tail.Equals(vertex)).ToList();
            foreach (var edge in edgesToRemove)
            {
                edges.Remove(edge);
            }
        }

        private bool AreSymmetric(Edge<TValue> a, Edge<TValue> b) =>
            a.Head.Equals(b.Tail) && a.Tail.Equals(b.Head) && a.Weight == b.Weight;
    }
}
