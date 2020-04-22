namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Requirements
    {
        public Experience Experience { get; }
        public Attributes Attributes { get; }

        public Requirements(Experience experience, Attributes attributes) =>
            (Experience, Attributes) = (experience, attributes);

        public bool AreMet(Experience experience, Attributes attributes) =>
            Experience.Level >= experience.Level &&
            Attributes.Strength >= attributes.Strength &&
            Attributes.Dexterity >= attributes.Dexterity &&
            Attributes.Inteligence >= attributes.Inteligence;
    }
}