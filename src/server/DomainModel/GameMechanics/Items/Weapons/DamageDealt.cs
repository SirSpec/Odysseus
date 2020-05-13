using System;

namespace Odysseus.DomainModel.GameMechanics.Items.Weapons
{
    public readonly struct DamageDealt
    {
        private const int Minimum = 0;

        public int Value { get; }
        public DamageType Type { get; }

        public DamageDealt(int value, DamageType type)
        {
            if (value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

            (Value, Type) = (value, type);
        }
    }
}