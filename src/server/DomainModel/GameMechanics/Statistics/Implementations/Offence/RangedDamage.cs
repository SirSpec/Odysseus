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
            var intelligence = statistics.Single(s => s is Strength);
            var baseValue = (Value + intelligence.Value);
            return baseValue + Enhancements.Sum(en => en.Enhance(baseValue));
        }
    }
}