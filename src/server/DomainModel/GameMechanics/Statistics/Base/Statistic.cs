using Odysseus.DomainModel.GameMechanics.Statistics.Enhancements;
using System;
using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Base
{
    public abstract class Statistic : IStatistic
    {
        protected IList<IEnhancement<IStatistic>> Enhancements { get; }

        public Statistic() =>
            Enhancements = new List<IEnhancement<IStatistic>>();

        public void AddEnhancement(IEnhancement<IStatistic> enhancement)
        {
            if (!Enhancements.Contains(enhancement)) Enhancements.Add(enhancement);
            else throw new InvalidOperationException($"{nameof(enhancement)}:{enhancement} already exists.");
        }

        public void RemoveEnhancement(IEnhancement<IStatistic> enhancement)
        {
            if (Enhancements.Contains(enhancement)) Enhancements.Remove(enhancement);
            else throw new InvalidOperationException($"{nameof(enhancement)}:{enhancement} does not exist.");
        }
    }
}