using System.Collections.Generic;

namespace Odysseus.DomainModel.Statistics.Base
{
    public interface IDerivedStatistic : IStatistic
    {
        int DeriveValue(IEnumerable<IPrimaryStatistic> statistics);
    }
}