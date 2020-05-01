using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Defence
{
    public abstract class Resistance : Statistic, IPrimaryStatistic
    {
        public const int Minimum = 0;
        public const int Maximum = 70;

        public int Value => EnhancementsValue <= Minimum
            ? Minimum
            : EnhancementsValue >= Maximum
                ? Maximum
                : EnhancementsValue;

        private int EnhancementsValue => Enhancements.Sum(enhancement => enhancement.Enhance(Minimum));
    }
}