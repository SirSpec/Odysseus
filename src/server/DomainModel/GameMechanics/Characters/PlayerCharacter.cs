using Odysseus.DomainModel.GameMechanics.Experience;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Offence;
using Odysseus.DomainModel.GameMechanics.Statistics;
using System;
using Odysseus.DomainModel.GameMechanics.Inventory;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Main;
using System.Linq;
using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Defence;

namespace Odysseus.DomainModel.GameMechanics
{
    public class PlayerCharacter
    {
        public string Name { get; }
        public int SkillPoints { get; private set; }
        public ExperiencePool Experience { get; }
        public StatisticsSet BaseStatistics { get; }
        public EnergyPool EnergyPool { get; }
        public InventorySet Inventory { get; }
        public SpellBook SpellBook { get; }

        public PlayerCharacter(string name)
        {
            Name = name;

            SkillPoints = 1;
            Experience = new ExperiencePool(0);
            Experience.LeveledUp += OnLeveledUpHandler;

            BaseStatistics = new StatisticsSet();
            EnergyPool = new EnergyPool(BaseStatistics.GetDerivedStatistic<Health>());
            var eq = new Equipment();
            eq.Equiped += OnEquiped;

            Inventory = new InventorySet(eq, new Backpack(10), new Weight(10));
            SpellBook = new SpellBook();
        }

        public int Attack()
        {
            return BaseStatistics.GetDerivedStatistic<MeleeDamage>();
        }

        public void TakeDamage(Damage damage)
        {
            var d = damage switch
            {
                Damage dmg when dmg is MeleeDamage || dmg is RangedDamage => dmg.Value - BaseStatistics.GetPrimaryStatistic<Armor>(),
                FireDamage dmg => dmg.Value - BaseStatistics.GetPrimaryStatistic<FireResistance>(),
                IceDamage dmg => dmg.Value - BaseStatistics.GetPrimaryStatistic<IceResistance>(),
                LightningDamage dmg => dmg.Value - BaseStatistics.GetPrimaryStatistic<LightningResistance>(),
                _ => throw new InvalidCastException(),
            };

            EnergyPool.Decrease(d);
        }

        public void OnEquiped(object _, EquipedEventArgs args)
        {
            var oldMods = args.OldItem?.Enhancements ?? Enumerable.Empty<IEnhancement<IStatistic>>();
            foreach (var mod in oldMods)
            {
                BaseStatistics.Remove(mod);
            }

            var newMods = args.NewItem?.Enhancements ?? Enumerable.Empty<IEnhancement<IStatistic>>();
            foreach (var mod in newMods)
            {
                BaseStatistics.Apply(mod);
            }
        }

        public void IncreaseStrength()
        {
            if (SkillPoints > 0)
            {
                BaseStatistics.GetStatistics<Strength>().Single().LevelUp();
                --SkillPoints;
            }
            else throw new InvalidOperationException($"Not enough {nameof(SkillPoints)}:{SkillPoints}.");
        }

        private void OnLeveledUpHandler(object _, Level level)
        {
            if (level.Value > Experience.Level.Value)
            {
                SkillPoints += level.Value - Experience.Level.Value;
                BaseStatistics.GetStatistics<Health>().Single().LevelUp();
                BaseStatistics.GetStatistics<Mana>().Single().LevelUp();
            }
        }
    }
}
