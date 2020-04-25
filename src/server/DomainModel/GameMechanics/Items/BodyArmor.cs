﻿using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanics
{
    public class BodyArmor : IItem
    {
        public string Name { get; }
        public double Weight { get; }
        public Requirements Requirements { get; }
        public IEnumerable<IModifier<IStatistic>> Modifiers { get; }
        public Armor Armor { get; }

        public BodyArmor(string name, double weight, Requirements requirements, IEnumerable<IModifier<IStatistic>> modifiers, Armor armor) =>
            (Name, Weight, Requirements, Modifiers, Armor) = (name, weight, requirements, modifiers, armor);
    }
}