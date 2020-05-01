using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes
{
    public abstract class CharacterAttribute : Statistic, IPrimaryStatistic, ILevelable
    {
        private const int Minimum = 1;
        private int BaseValue { get; set; } = Minimum;
        public int Value => BaseValue + Enhancements.Sum(Enhancement => Enhancement.Enhance(BaseValue));

        public void LevelUp() =>
            BaseValue++;
    }
}