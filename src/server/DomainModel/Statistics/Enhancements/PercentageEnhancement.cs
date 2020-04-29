﻿using Odysseus.DomainModel.Statistics.Base;

namespace Odysseus.DomainModel.Statistics.Enhancements
{
    public class PercentageEnhancement<TStatistic> : IEnhancement<TStatistic> where TStatistic : class, IStatistic
    {
        private readonly int percentage;

        public PercentageEnhancement(int percentage) =>
            this.percentage = percentage;

        public int Enhance(int value) => value * percentage / 100;
    }
}