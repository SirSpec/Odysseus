using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using System;
using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Offence
{
    public abstract class Damage : Statistic, IDerivedStatistic
    {
        private const int Minimum = 0;
        protected int baseValue;

        public int BaseValue
        {
            set => baseValue = value >= Minimum
                ? value
                : throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");
        }

        public abstract int DeriveValue(IEnumerable<IPrimaryStatistic> statistics);
    }
}