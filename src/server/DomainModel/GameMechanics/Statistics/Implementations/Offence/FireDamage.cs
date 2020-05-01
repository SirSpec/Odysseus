using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Offence
{
    public class FireDamage : Damage
    {
        public override int DeriveValue(IEnumerable<IPrimaryStatistic> statistics)
        {
            var intelligence = statistics.Single(statistic => statistic is Intelligence);
            var derivedValue = (baseValue + intelligence.Value);
            return derivedValue + Enhancements.Sum(enhancement => enhancement.Enhance(derivedValue));
        }
    }
}