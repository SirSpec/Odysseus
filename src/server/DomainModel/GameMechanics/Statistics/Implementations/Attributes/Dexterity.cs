using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes
{
    public class Dexterity : Statistic, IPrimaryStatistic, ILevelable
    {
        private const int Minimum = 1;
        public int Value => BaseValue + Enhancements.Sum(e => e.Enhance(BaseValue));
        public int BaseValue { get; set; } = Minimum;

        public void LevelUp()
        {
            BaseValue++;
        }
    }
}