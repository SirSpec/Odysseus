using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanics
{
    public interface IItem
    {
        public string Name { get; }
        public double Weight { get; }
        public Requirements Requirements { get; }
        public IEnumerable<IModifier<IStatistic>> Modifiers { get; }
    }
}