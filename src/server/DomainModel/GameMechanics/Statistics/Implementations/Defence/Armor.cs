using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using System;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Defence
{
    public class Armor : Statistic, IPrimaryStatistic
    {
        private const int Minimum = 0;
        private int baseValue;

        public int Value => baseValue + Enhancements.Sum(enhancement => enhancement.Enhance(baseValue));
        public int BaseValue
        {
            set => baseValue = value >= Minimum
                ? value
                : throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");
        }

        public Armor() =>
            BaseValue = Minimum;
    }
}