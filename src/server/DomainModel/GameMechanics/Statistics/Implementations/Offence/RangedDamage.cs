using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Offence
{
    public class RangedDamage : Damage
    {
        public override int DeriveValue(IEnumerable<IPrimaryStatistic> statistics)
        {
            var dexterity = statistics.Single(statistic => statistic is Dexterity);
            var derivedValue = (baseValue + dexterity.Value);
            return derivedValue + Enhancements.Sum(enhancement => enhancement.Enhance(derivedValue));
        }
    }
}