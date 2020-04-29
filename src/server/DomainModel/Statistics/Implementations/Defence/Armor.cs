using Odysseus.DomainModel.Statistics.Base;
using System.Linq;

namespace Odysseus.DomainModel.Statistics.Implementations.Defence
{
    public class Armor : Statistic, IPrimaryStatistic, ILevelable
    {
        private const int Minimum = 0;
        public int Value => BaseValue + Enhancements.Sum(e => e.Enhance(BaseValue));
        public int BaseValue { get; set; }

        public Armor() =>
            BaseValue = Minimum;

        public void LevelUp()
        {
            BaseValue++;
        }
    }
}