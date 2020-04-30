using Odysseus.DomainModel.GameMechanics.Experience;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Offence;
using Odysseus.DomainModel.GameMechanics.Statistics;
using System;
using Odysseus.DomainModel.GameMechanics.Inventory;

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
            //EnergyPool = new EnergyPool(BaseStatistics.GetStatistic<Health>().Value);
            var eq = new Equipment();
            eq.Equiped += OnEquiped;

            Inventory = new InventorySet(eq, new Backpack(10), 10);
            SpellBook = new SpellBook();
        }

        public int Attack()
        {
            return 0;//BaseStatistics.GetStatistic<MeleeDamage>();
        }

        public void TakeDamage(MeleeDamage damage)
        {
            //var d = damage switch
            //{
            //    Damage dmg when dmg is MeleeDamage || dmg is RangedDamage => dmg.Value - BaseStatistics.GetStatistic<Armor>().Value,
            //    FireDamage dmg => dmg.Value - BaseStatistics.GetStatistic<FireResistance>().Value,
            //    IceDamage dmg => dmg.Value - BaseStatistics.GetStatistic<IceDamage>().Value,
            //    LightningDamage dmg => dmg.Value - BaseStatistics.GetStatistic<LightningDamage>().Value,
            //    _ => throw new InvalidCastException(),
            //};

            //EnergyPool.Decrease(d);
        }

        public void OnEquiped(object _, EquipedEventArgs args)
        {
            //var oldMods = args.OldItem?.Modifiers ?? Enumerable.Empty<IModifier<Statistic>>();
            //foreach (var mod in oldMods)
            //{
            //    BaseStatistics.Remove(mod);
            //}

            //var newMods = args.NewItem?.Modifiers ?? Enumerable.Empty<IModifier<Statistic>>();
            //foreach (var mod in newMods)
            //{
            //    BaseStatistics.Apply(mod);
            //}
        }

        public void IncreaseStrength()
        {
            if (SkillPoints > 0)
            {
                //var strength = BaseStatistics.GetStatistic<Strength>();
                //var newStrength = new Strength(strength.Value + 1);
                //BaseStatistics.Change(newStrength);
                //--SkillPoints;
                ////might not be needed
                //var newHealth = new Health(Experience.Level, newStrength);
                //BaseStatistics.Change(newHealth);
            }
            else throw new InvalidOperationException($"Not enough {nameof(SkillPoints)}:{SkillPoints}.");
        }

        private void OnLeveledUpHandler(object _, Level level)
        {
            if (level.Value > Experience.Level.Value)
            {
                //SkillPoints += level.Value - Experience.Level.Value;
                //var strength = BaseStatistics.GetStatistic<Strength>();
                //var newHealth = new Health(Experience.Level, new Strength(strength.Value));
                //BaseStatistics.Change(newHealth);

                //var intelligence = BaseStatistics.GetStatistic<Intelligence>();
                //var newMana = new Mana(Experience.Level, new Intelligence(intelligence.Value));
                //BaseStatistics.Change(newMana);
            }
        }
    }
}
