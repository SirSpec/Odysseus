using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public abstract class CharacterAttribute : Statistic
    {
        protected const int Minimum = 1;
        protected override int BaseValue { get; }

        public CharacterAttribute() =>
            BaseValue = Minimum;

        public CharacterAttribute(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            BaseValue = value;
        }

        public abstract CharacterAttribute Increase();
    }
}