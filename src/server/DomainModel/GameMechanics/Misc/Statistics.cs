using Odysseus.Framework.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Statistics
    {
        private readonly List<IStatistic> statistics;

        public IEnumerable<IStatistic> All => statistics;

        public Statistics()
        {
            statistics = Assembler.CreateImplementationOf<IStatistic>().ToList();
        }

        public IStatistic GetStatistic<TStatistic>() where TStatistic : class, IStatistic, new() =>
            FindStatistic(typeof(TStatistic));

        public void Change(IStatistic newStatistic)
        {
            var index = statistics.FindIndex(statistic => statistic.GetType() == newStatistic.GetType());
            statistics[index] = newStatistic;
        }

        public void Apply<TStatistic>(IModifier<TStatistic> modifier) where TStatistic : class, IStatistic, new()
        {
            var statistic = FindStatistic(typeof(TStatistic));
            var newStatistic = modifier.Modify(statistic);
            Change(newStatistic);
        }

        private IStatistic FindStatistic(Type type) =>
            statistics.First(statistic => statistic.GetType() == type);
    }
}