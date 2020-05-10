using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Main
{
    public class Health : Statistic, IDerivedStatistic, ILevelable
    {
        private const int Minimum = 1;
        private const int HealthPerLevel = 12;
        private int Level { get; set; } = Minimum;

        public void LevelUp() => Level++;

        public int DeriveValue(IEnumerable<IPrimaryStatistic> statistics)
        {
            var strength = statistics.Single(statistic => statistic is Strength);
            var baseValue = HealthPerLevel * Level + strength.Value;
            return baseValue + Enhancements.Sum(enhancement => enhancement.Enhance(baseValue));
        }
    }
}