﻿using Odysseus.DomainModel.Statistics.Base;
using Odysseus.DomainModel.Statistics.Implementations.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Offence
{
    public class RangedDamage : Statistic, IDerivedStatistic
    {
        public int Value { get; }

        public int DeriveValue(IEnumerable<IPrimaryStatistic> statistics)
        {
            var intelligence = statistics.Single(s => s is Strength);
            var baseValue = (Value + intelligence.Value);
            return baseValue + Enhancements.Sum(en => en.Enhance(baseValue));
        }
    }
}