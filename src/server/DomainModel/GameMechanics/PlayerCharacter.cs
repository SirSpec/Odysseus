using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class PlayerCharacter
    {
        public string Name { get; }
        public int SkillPoints { get; private set; }
        public Statistics Statistics { get; }
        public Experience Experience { get; }
        public Inventory Inventory { get; }
        public SpellBook SpellBook { get; }
        public EnergyPool EnergyPool { get; }

        public PlayerCharacter(string name)
        {
            Name = name;
            Experience = new Experience(0);
            Experience.LeveledUp += OnLeveledUpHandler;

            Statistics = new Statistics();
            Inventory = new Inventory(new Equipment(), new Backpack(10), 10);
            SpellBook = new SpellBook();
            EnergyPool = new EnergyPool(Statistics.GetStatistic<Health>().Value);
        }

        public MeleeDamage Attack()
        {
            return new MeleeDamage(1);
        }

        public void TakeDamage(MeleeDamage damage)
        {
            EnergyPool.Decrease(damage.Value);
        }

        private void OnLeveledUpHandler(object sender, Level level)
        {
            if (level.Value > Experience.Level.Value)
                SkillPoints += level.Value - Experience.Level.Value;
        }
    }
}
