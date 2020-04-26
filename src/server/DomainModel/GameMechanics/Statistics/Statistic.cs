using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics
{
    public abstract class Statistic
    {
        protected abstract int BaseValue { get; }
        private readonly IList<IModifier<Statistic>> modifiers;
        public int Value => BaseValue + modifiers.Sum(modifier => modifier.Modify(BaseValue));

        public Statistic() => modifiers = new List<IModifier<Statistic>>();

        public void AddModifier(IModifier<Statistic> modifier)
        {
            if (!modifiers.Contains(modifier)) modifiers.Add(modifier);
            else throw new InvalidOperationException($"{nameof(modifier)}:{modifier} already exists.");
        }

        public void RemoveModifier(IModifier<Statistic> modifier)
        {
            if (modifiers.Contains(modifier)) modifiers.Remove(modifier);
            else throw new InvalidOperationException($"{nameof(modifier)}:{modifier} does not exist.");
        }
    }
}