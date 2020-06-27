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
using Odysseus.DomainModel.GameMechanics.Items.Weapons;
using Odysseus.DomainModel.GameMechanics.Spells;

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

        public DamageDealt Attack()
        {
            return Inventory.Equipment.IsUnarmed
                ? new DamageDealt(StatisticsSet.GetDerivedStatistic<MeleeDamage>(), DamageType.Melee)
                : new DamageDealt(Inventory.Equipment.WeaponDamageType switch
                {
                    DamageType.Melee => StatisticsSet.GetDerivedStatistic<MeleeDamage>(),
                    DamageType.Ranged => StatisticsSet.GetDerivedStatistic<RangedDamage>(),
                    DamageType.Fire => StatisticsSet.GetDerivedStatistic<FireDamage>(),
                    DamageType.Ice => StatisticsSet.GetDerivedStatistic<IceDamage>(),
                    DamageType.Lightning => StatisticsSet.GetDerivedStatistic<LightningDamage>(),
                    _ => throw new ArgumentException()
                }, Inventory.Equipment.WeaponDamageType);
        }

        public void TakeDamage(DamageDealt damage)
        {
            var reducedDamage = damage.Type switch
            {
                DamageType.Melee => damage.Value - StatisticsSet.GetPrimaryStatistic<Armor>(),
                DamageType.Ranged => damage.Value - StatisticsSet.GetPrimaryStatistic<Armor>(),
                DamageType.Fire => damage.Value - damage.Value * StatisticsSet.GetPrimaryStatistic<FireResistance>() / 100,
                DamageType.Ice => damage.Value - damage.Value * StatisticsSet.GetPrimaryStatistic<IceResistance>() / 100,
                DamageType.Lightning => damage.Value - damage.Value * StatisticsSet.GetPrimaryStatistic<LightningResistance>() / 100,
                _ => throw new ArgumentException()
            };

            HealthPool.Decrease(reducedDamage);
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
                StatisticsSet.GetStatistic<Strength>().LevelUp();
                --SkillPoints;
            }
            else throw new InvalidOperationException($"Not enough {nameof(SkillPoints)}:{SkillPoints}.");
        }

        private void OnLeveledUpHandler(object _, Level level)
        {
            if (level.Value > Experience.Level.Value)
            {
                SkillPoints += level.Value - Experience.Level.Value;
                StatisticsSet.GetStatistic<Health>().LevelUp();
                StatisticsSet.GetStatistic<Mana>().LevelUp();
            }
        }
    }
}