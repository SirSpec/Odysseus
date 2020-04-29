using Odysseus.DomainModel.Statistics.Base;
using Odysseus.DomainModel.Statistics.Implementations.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.Statistics.Implementations.Main
{
    public class Health : Statistic, IDerivedStatistic, ILevelable
    {
        private const int Minimum = 1;
        private const int HealthPerLevel = 12;
        private int Level { get; set; } = Minimum;

        public void LevelUp()
        {
            Level++;
        }

        public int DeriveValue(IEnumerable<IPrimaryStatistic> statistics)
        {
            var strength = statistics.Single(s => s is Strength);
            var baseValue = (HealthPerLevel * Level + strength.Value);
            return baseValue + Enhancements.Sum(en => en.Enhance(baseValue));
        }
    }
}