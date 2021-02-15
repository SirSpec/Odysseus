using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.Framework.Mathematica.Graphs
{
    // https://en.wikipedia.org/wiki/Binary_heap
    public class BinaryHeap<TKey, TValue> where TKey : IComparable<TKey>
    {
        private readonly IList<Node<TKey, TValue>> nodes;

        public IEnumerable<Node<TKey, TValue>> Nodes => nodes;
        public int Count => nodes.Count;
        public bool IsEmpty => Count == 0;

        public BinaryHeap() =>
            nodes = new List<Node<TKey, TValue>>();

        public BinaryHeap(IList<Node<TKey, TValue>> nodes)
        {
            this.nodes = nodes;
            BuildHeap();
        }

        public Node<TKey, TValue> ExtractMinimum()
        {
            var minimum = nodes.First();
            var last = nodes.Last();

            nodes.RemoveAt(nodes.Count - 1);
            if (nodes.Count > 0)
            {
                nodes[0] = last;
                Heapify(0);
            }

            return minimum;
        }

        public void Insert(TKey key, TValue value)
        {
            nodes.Add(new Node<TKey, TValue>(key, value));
            SiftUp(nodes.Count - 1);
        }

        private void SiftUp(int nodeIndex)
        {
            var parentIndex = GetParentIndex(nodeIndex);
            while (parentIndex != nodeIndex && nodes[nodeIndex] < nodes[parentIndex])
            {
                Swap(nodeIndex, parentIndex);
                nodeIndex = parentIndex;
                parentIndex = GetParentIndex(nodeIndex);
            }
        }

        private void BuildHeap()
        {
            for (int i = nodes.Count / 2; i >= 0; i--)
                Heapify(i);
        }

        private void Heapify(int nodeIndex)
        {
            int smallest = GetIndexOfSmallestNodeInHierarchy(nodeIndex);

            if (smallest != nodeIndex)
            {
                Swap(nodeIndex, smallest);
                Heapify(smallest);
            }
        }

        private int GetIndexOfSmallestNodeInHierarchy(int nodeIndex)
        {
            int leftChildIndex = GetLeftChildIndex(nodeIndex);
            int rightChildIndex = GetRightChildIndex(nodeIndex);
            int smallest = nodeIndex;

            if (leftChildIndex < nodes.Count && nodes[leftChildIndex] < nodes[nodeIndex])
                smallest = leftChildIndex;

            if (rightChildIndex < nodes.Count && nodes[rightChildIndex] < nodes[smallest])
                smallest = rightChildIndex;

            return smallest;
        }

        private void Swap(int nodeIndexA, int nodeIndexB)
        {
            var tmp = nodes[nodeIndexA];
            nodes[nodeIndexA] = nodes[nodeIndexB];
            nodes[nodeIndexB] = tmp;
        }

        private int GetParentIndex(int nodeIndex) =>
            (nodeIndex - 1) / 2;

        private int GetLeftChildIndex(int parentIndex) =>
            2 * parentIndex + 1;

        private int GetRightChildIndex(int parentIndex) =>
            2 * parentIndex + 2;
    }
}