using Odysseus.DomainModel.GameMechanics.Experience;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;

namespace Odysseus.DomainModel.GameMechanics.Items
{
    public readonly struct Requirements
    {
        public Level Level { get; }
        public Strength Strength { get; }
        public Dexterity Dexterity { get; }
        public Intelligence Intelligence { get; }

        public Requirements(Level level, Strength strength, Dexterity dexterity, Intelligence intelligence) =>
            (Level, Strength, Dexterity, Intelligence) = (level, strength, dexterity, intelligence);

        public bool AreMet(Level level, Strength strength, Strength dexterity, Strength intelligence) =>
            Level.Equals(level) &&
            Strength.Value == strength.Value &&
            Dexterity.Value == dexterity.Value &&
            Intelligence.Value == intelligence.Value;
    }
}