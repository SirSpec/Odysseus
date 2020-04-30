using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Main
{
    public class Mana : Statistic, IDerivedStatistic, ILevelable
    {
        private const int Minimum = 1;
        private const int ManaPerLevel = 6;
        private int Level { get; set; } = Minimum;

        public void LevelUp()
        {
            Level++;
        }

        public int DeriveValue(IEnumerable<IPrimaryStatistic> statistics)
        {
            var intelligence = statistics.Single(s => s is Intelligence);
            var baseValue = (ManaPerLevel * Level + intelligence.Value);
            return baseValue + Enhancements.Sum(en => en.Enhance(baseValue));
        }
    }
}