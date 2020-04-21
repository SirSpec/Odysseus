using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Attributes
    {
        public int Strength { get; }
        public int Dexterity { get; }
        public int Inteligence { get; }

        public Attributes(int strength, int dexterity, int inteligence)
        {
            if (strength < 0 || dexterity < 0 || inteligence < 0)
                throw new ArgumentException("Attributes cannot be less than 0.");

            (Strength, Dexterity, Inteligence) = (strength, dexterity, inteligence);
        }
    }
}
