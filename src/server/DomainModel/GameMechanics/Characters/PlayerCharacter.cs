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
        public StatisticsSet StatisticsSet { get; }
        public EnergyPool HealthPool { get; }
        public EnergyPool ManaPool { get; }
        public InventorySet Inventory { get; }
        public SpellBook SpellBook { get; }

        public PlayerCharacter(string name)
        {
            Name = name;

            SkillPoints = 1;
            Experience = new ExperiencePool(0);
            Experience.LeveledUp += OnLeveledUpHandler;

            StatisticsSet = new StatisticsSet();

            HealthPool = new EnergyPool(StatisticsSet.GetDerivedStatistic<Health>());
            ManaPool = new EnergyPool(StatisticsSet.GetDerivedStatistic<Mana>());

            var equipment = new Equipment();
            equipment.Equiped += OnEquiped;

            Inventory = new InventorySet(equipment, new Backpack(10), new Weight(10));
            SpellBook = new SpellBook();
        }

        public int Attack()
        {
            return StatisticsSet.GetDerivedStatistic<MeleeDamage>();
        }

        public void TakeDamage(int damage)
        {
            //var d = damage switch
            //{
            //    Damage dmg when dmg is MeleeDamage || dmg is RangedDamage => StatisticsSet.GetPrimaryStatistic<Armor>(),
            //    FireDamage dmg => StatisticsSet.GetPrimaryStatistic<FireResistance>(),
            //    IceDamage dmg => StatisticsSet.GetPrimaryStatistic<IceResistance>(),
            //    LightningDamage dmg => StatisticsSet.GetPrimaryStatistic<LightningResistance>(),
            //    _ => throw new InvalidCastException(),
            //};
            HealthPool.Decrease(damage);
        }

        public void OnEquiped(object _, EquipedEventArgs args)
        {
            var oldMods = args.OldItem?.Enhancements ?? Enumerable.Empty<IEnhancement<IStatistic>>();
            foreach (var mod in oldMods)
            {
                StatisticsSet.Remove(mod);
            }

            var newMods = args.NewItem?.Enhancements ?? Enumerable.Empty<IEnhancement<IStatistic>>();
            foreach (var mod in newMods)
            {
                StatisticsSet.Apply(mod);
            }
        }

        public void IncreaseStrength()
        {
            if (SkillPoints > 0)
            {
                StatisticsSet.GetStatistics<Strength>().Single().LevelUp();
                --SkillPoints;
            }
            else throw new InvalidOperationException($"Not enough {nameof(SkillPoints)}:{SkillPoints}.");
        }

        private void OnLeveledUpHandler(object _, Level level)
        {
            if (level.Value > Experience.Level.Value)
            {
                SkillPoints += level.Value - Experience.Level.Value;
                StatisticsSet.GetStatistics<Health>().Single().LevelUp();
                StatisticsSet.GetStatistics<Mana>().Single().LevelUp();
            }
        }
    }
}