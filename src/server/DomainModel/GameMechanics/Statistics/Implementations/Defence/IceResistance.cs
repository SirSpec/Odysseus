using Odysseus.DomainModel.GameMechanics.Statistics.Base;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Defence
{
    public class IceResistance : Statistic, IPrimaryStatistic, ILevelable
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