using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Offence
{
    public class IceDamage : Damage
    {
        public override int DeriveValue(IEnumerable<IPrimaryStatistic> statistics)
        {
            var intelligence = statistics.Single(s => s is Intelligence);
            var baseValue = (Value + intelligence.Value);
            return baseValue + Enhancements.Sum(en => en.Enhance(baseValue));
        }
    }
}