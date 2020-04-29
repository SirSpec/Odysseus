using Odysseus.DomainModel.Statistics.Base;
using Odysseus.DomainModel.Statistics.Enhancements;
using Odysseus.Framework.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.Statistics
{
    public class StatisticsSet
    {
        private readonly IEnumerable<IStatistic> statistics;

        public StatisticsSet() =>
            statistics = Assembler.CreateImplementationsOf<IStatistic>().ToList();

        public IEnumerable<TStatistic> GetStatistics<TStatistic>() where TStatistic : IStatistic =>
            FindStatistics(typeof(TStatistic))
                .Select(statistic => (TStatistic)statistic);

        public int GetPrimaryStatistic<TStatistic>() where TStatistic : IPrimaryStatistic =>
            GetStatistics<TStatistic>()
                .Single()
                .Value;

        public int GetDerivedStatistic<TStatistic>() where TStatistic : IDerivedStatistic =>
            GetStatistics<TStatistic>()
                .Single()
                .DeriveValue(GetStatistics<IPrimaryStatistic>());

        public void Apply(params IEnhancement<IStatistic>[] enhancements)
        {
            foreach (var enhancement in enhancements)
            {
                var statisticType = enhancement.GetType().GenericTypeArguments.Single();
                FindStatistics(statisticType).Single().AddEnhancement(enhancement);
            }
        }

        public void Remove(params IEnhancement<IStatistic>[] enhancements)
        {
            foreach (var enhancement in enhancements)
            {
                var statisticType = enhancement.GetType().GenericTypeArguments.Single();
                FindStatistics(statisticType).Single().RemoveEnhancement(enhancement);
            }
        }

        private IEnumerable<IStatistic> FindStatistics(Type type) =>
            statistics.Where(statistic => type.IsAssignableFrom(statistic.GetType()));
    }
}
