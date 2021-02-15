using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.Framework.Mathematica.Graphs
{
    // https://en.wikipedia.org/wiki/Disjoint-set_data_structure
    public class DisjointSet<TValue> where TValue : notnull, IEquatable<TValue>
    {
        private readonly IList<(TValue Element, TValue Parent)> set;

        public DisjointSet(IEnumerable<TValue> values) =>
            set = values.Select(value => (value, value)).ToList();

        public bool HaveTheSameRoot(TValue elementA, TValue elementB)
        {
            var elementRootA = FindRoot(elementA);
            var elementRootB = FindRoot(elementB);

            return elementRootA.Equals(elementRootB);
        }

        public TValue FindRoot(TValue element)
        {
            var parent = this[element];

            if (!parent.Equals(element)) return FindRoot(parent);
            else return element;
        }

        public void Union(TValue subsetElementA, TValue subsetElementB)
        {
            var subsetRootA = FindRoot(subsetElementA);
            var subsetRootB = FindRoot(subsetElementB);

            this[subsetRootA] = subsetRootB;
        }

        private TValue this[TValue element]
        {
            get => set.First(setPair => setPair.Element.Equals(element)).Parent;
            set
            {
                var setPair = set.First(setPair => setPair.Element.Equals(element));
                var pairIndex = set.IndexOf(setPair);
                setPair.Parent = value;
                set.RemoveAt(pairIndex);
                set.Insert(pairIndex, setPair);
            }
        }
    }
}
