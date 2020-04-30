using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Base
{
    public interface IDerivedStatistic : IStatistic
    {
        int DeriveValue(IEnumerable<IPrimaryStatistic> statistics);
    }
}