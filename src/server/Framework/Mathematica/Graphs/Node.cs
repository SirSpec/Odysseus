using System;

namespace Odysseus.Framework.Mathematica.Graphs
{
    public class Node<TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key { get; }
        public TValue Value { get; }

        public Node(TKey key, TValue value) =>
            (Key, Value) = (key, value);

        public static bool operator <(Node<TKey, TValue> left, Node<TKey, TValue> right) =>
            left.Key.CompareTo(right.Key) < 0;

        public static bool operator >(Node<TKey, TValue> left, Node<TKey, TValue> right) =>
            left.Key.CompareTo(right.Key) > 0;
    }
}