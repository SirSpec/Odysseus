using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Offence
{
    public abstract class Damage : Statistic, IDerivedStatistic
    {
        public int Value { get; }

        public abstract int DeriveValue(IEnumerable<IPrimaryStatistic> statistics);
    }
}