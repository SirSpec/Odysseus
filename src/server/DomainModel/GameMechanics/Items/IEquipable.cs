using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Enhancements;
using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanics.Items
{
    public interface IEquipable : IItem
    {
        public Requirements Requirements { get; }
        public IEnumerable<IEnhancement<IStatistic>> Modifiers { get; }
    }
}