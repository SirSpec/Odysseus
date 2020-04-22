using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Damage
    {
        public int Value { get; }
        public DamageType Type { get; }

        public Damage(int value, DamageType type)
        {
            if(value < 0)
                throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");

            (Value, Type) = (value, type);
        }
    }
}
