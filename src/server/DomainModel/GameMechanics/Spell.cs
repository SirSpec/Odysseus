namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Spell
    {
        public string Name { get; }
        public Effect Effect { get; }
        public Requirements Requirements { get; }

        public Spell(string name, Effect effect, Requirements requirements) =>
            (Name, Effect, Requirements) = (name, effect, requirements);
    }
}
