using Odysseus.DomainModel.Statistics.Base;
using System.Linq;

namespace Odysseus.DomainModel.Statistics.Implementations.Attributes
{
    public class Intelligence : Statistic, IPrimaryStatistic, ILevelable
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