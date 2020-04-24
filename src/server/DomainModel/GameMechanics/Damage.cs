using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Damage
    {
        private const int Minimum = 0;

        public int Value { get; }
        public DamageType Type { get; }

        public Damage(int value, DamageType type)
        {
            if(value < Minimum)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");

            (Value, Type) = (value, type);
        }
    }
}
