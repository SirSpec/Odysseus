namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Requirements
    {
        public Level Level { get; }
        public Strength Strength { get; }
        public Dexterity Dexterity { get; }
        public Intelligence Intelligence { get; }

        public Requirements(Level level, Strength strength, Dexterity dexterity, Intelligence intelligence) =>
            (Level, Strength, Dexterity, Intelligence) = (level, strength, dexterity, intelligence);
    }
}