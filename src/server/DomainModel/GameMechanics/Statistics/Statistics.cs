using Odysseus.Framework.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Statistics
    {
        private readonly List<Statistic> statistics;

        public IEnumerable<Statistic> All => statistics;

        public Statistics() =>
            statistics = Assembler.CreateImplementationOf<Statistic>().ToList();

        public TStatistic GetStatistic<TStatistic>() where TStatistic : Statistic =>
            (TStatistic)FindStatistic(typeof(TStatistic));

        public void Change(Statistic newStatistic)
        {
            var index = statistics.FindIndex(statistic => statistic.GetType() == newStatistic.GetType());
            statistics[index] = newStatistic;
        }

        public void Apply<TStatistic>(IModifier<TStatistic> modifier) where TStatistic : Statistic =>
            FindStatistic(typeof(TStatistic)).AddModifier(modifier);

        public void Remove<TStatistic>(IModifier<TStatistic> modifier) where TStatistic : Statistic =>
            FindStatistic(typeof(TStatistic)).RemoveModifier(modifier);

        private Statistic FindStatistic(Type type) =>
            statistics.First(statistic => statistic.GetType() == type);
    }
}