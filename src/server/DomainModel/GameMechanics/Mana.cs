namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Mana
    {
        public int Value { get; }

        public Mana(Experience experience, Attributes attributes)
        {
            Value = experience.Level + attributes.Inteligence;
        }
    }
}
