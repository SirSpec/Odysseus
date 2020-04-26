using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class PlayerCharacter
    {
        public string Name { get; }
        public int SkillPoints { get; private set; }
        public Experience Experience { get; }
        public Statistics BaseStatistics { get; }
        public EnergyPool EnergyPool { get; }
        public Inventory Inventory { get; }
        public SpellBook SpellBook { get; }

        public PlayerCharacter(string name)
        {
            Name = name;

            SkillPoints = 1;
            Experience = new Experience(0);
            Experience.LeveledUp += OnLeveledUpHandler;

            BaseStatistics = new Statistics();
            EnergyPool = new EnergyPool(BaseStatistics.GetStatistic<Health>().Value);
            var eq = new Equipment();
            eq.Equiped += OnEquiped;

            Inventory = new Inventory(eq, new Backpack(10), 10);
            SpellBook = new SpellBook();
        }

        public Damage Attack()
        {
            return BaseStatistics.GetStatistic<Damage>();
        }

        public void TakeDamage(Damage damage)
        {
            EnergyPool.Decrease(damage.Value);
        }

        public void OnEquiped(object _, EquipedEventArgs args)
        {
            var oldMods = args.OldItem.Modifiers;
            foreach (var mod in oldMods)
            {
                BaseStatistics.Remove(mod);
            }

            var newMods = args.OldItem.Modifiers;
            foreach (var mod in newMods)
            {
                BaseStatistics.Apply(mod);
            }
        }

        public void IncreaseStrength()
        {
            if (SkillPoints > 0)
            {
                var strength = BaseStatistics.GetStatistic<Strength>();
                var newStrength = new Strength(strength.Value + 1);
                BaseStatistics.Change(newStrength);
                --SkillPoints;

                var newHealth = new Health(Experience.Level, newStrength);
                BaseStatistics.Change(newHealth);

                var newArmor = ((Armor)BaseStatistics.GetStatistic<Armor>()).Scale(newStrength);
                BaseStatistics.Change(newArmor);

                var meleeDamage = ((MeleeDamage)BaseStatistics.GetStatistic<MeleeDamage>()).Scale(newStrength);
                BaseStatistics.Change(meleeDamage);
            }
            else throw new InvalidOperationException($"Not enough {nameof(SkillPoints)}:{SkillPoints}.");
        }

        private void OnLeveledUpHandler(object _, Level level)
        {
            if (level.Value > Experience.Level.Value)
            {
                SkillPoints += level.Value - Experience.Level.Value;
                var strength = BaseStatistics.GetStatistic<Strength>();
                var newHealth = new Health(Experience.Level, new Strength(strength.Value));
                BaseStatistics.Change(newHealth);

                var intelligence = BaseStatistics.GetStatistic<Intelligence>();
                var newMana = new Mana(Experience.Level, new Intelligence(intelligence.Value));
                BaseStatistics.Change(newMana);
            }
        }
    }
}
