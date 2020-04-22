using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class PlayerCharacter
    {
        public string Name { get; }

        public PlayerCharacter(string name)
        {
            Name = name;
            Experience = new Experience(0);
            Experience.LeveledUp += OnLeveledUpHandler;

            Health = new Health(5, 5);
            Inventory = new Inventory(new Equipment(), new Backpack(10), 10);
            SpellBook = new SpellBook();
        }

        public Experience Experience { get; }
        public int SkillPoints { get; private set; }

        public Health Health { get; set; }
        public Mana Mana { get; }

        public Attributes Attributes { get; private set; }
        public Resistances Resistances { get; }

        public Inventory Inventory { get; }
        public SpellBook SpellBook { get; }

        public void IncreaseAttribute(Func<Attributes, Attributes> action)
        {
            Attributes = action(Attributes);
        }

        public Damage Attack()
        {
            return new Damage(1, DamageType.Physical);
        }

        public Effect Cast(Spell spell)
        {
            if (SpellBook.Contains(spell)) return spell.Effect;
            else throw new ArgumentException($"{nameof(SpellBook)} does not contain {nameof(spell)}:{spell.Name}.");
        }

        public void Learn(Spell spell)
        {
            if (spell.Requirements.AreMet(Experience, Attributes) && !SpellBook.Contains(spell))
            {
                SpellBook.Add(spell);
                //Event added
            }
            else
            {
                //Not added Event
            }
        }

        public void ReceiveDamage(Damage damage)
        {
            Health = Health.Decrease(damage.Value);
        }

        public void Equip(Item item)
        {
            if (item.Requirements.AreMet(Experience, Attributes))
            {
                //Event added
            }
            else
            {
                //Not added Event
            }
        }

        private void OnLeveledUpHandler(object sender, int level)
        {
            if (level > Experience.Level)
                SkillPoints += level - Experience.Level;
        }
    }
}
