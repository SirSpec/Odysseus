namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Health
    {
        public int Value { get; }

        public Health(Experience experience, Attributes attributes)
        {
            Value = experience.Level + attributes.Strength;
        }
    }
}
