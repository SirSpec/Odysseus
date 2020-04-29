using Odysseus.DomainModel.Statistics.Base;

namespace Odysseus.DomainModel.Statistics.Implementations.Defence
{
    public class LightningResistance : Statistic, IPrimaryStatistic, ILevelable
    {
        private const int Minimum = 0;
        private const int Maximum = 70;
        public int BaseValue { get; set; } = 0;

        public int Value => BaseValue >= Maximum ? Maximum : BaseValue;

        public void LevelUp()
        {
            BaseValue++;
        }
    }
}