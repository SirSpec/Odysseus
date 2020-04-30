﻿using Odysseus.DomainModel.GameMechanics.Statistics.Base;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Enhancements
{
    public class FlatEnhancement<TStatistic> : IEnhancement<TStatistic> where TStatistic : class, IStatistic
    {
        private readonly int value;

        public FlatEnhancement(int value) =>
            this.value = value;

        public int Enhance(int _) => value;
    }
}