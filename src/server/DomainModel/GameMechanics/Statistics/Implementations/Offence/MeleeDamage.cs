using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Offence
{
    public class MeleeDamage : Damage
    {
        public override int DeriveValue(IEnumerable<IPrimaryStatistic> statistics)
        {
            var strength = statistics.Single(statistic => statistic is Strength);
            var derivedValue = baseValue + strength.Value;
            return derivedValue + Enhancements.Sum(enhancement => enhancement.Enhance(derivedValue));
        }
    }
}