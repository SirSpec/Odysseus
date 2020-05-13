using System;

namespace Odysseus.DomainModel.GameMechanics.Items.Armor
{
    public readonly struct ArmorValue
    {
        private const int Minimum = 0;

        public int Value { get; }

        public ArmorValue(int value)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");
            
            Value = value;
        }
    }
}