using System;

namespace Odysseus.Infrastructure.WebApi.Hubs
{
    public class PlayerCharacter
    {
        public string Name { get; }

        public Experience Experience { get; }

        public Health Health { get; }
        public Mana Mana { get; }
        public Attributes Attributes { get; }
        public Resistances Resistances { get; }

        public Inventory Inventory { get; }
        public Equipment Equipment { get; }
        public SpellBook SpellBook { get; }

        public void GainExperience(int value) { }
        public void IncreaseAttribute(Func<Attributes, int> action) { } //???

        public Damage Attack() { return default; } //DealDamage
        public Effect CastSpell(Spell spell) { return default; }
        public void LearnSpell(Spell spell) { }
        public void TakeDamage(Damage damage) { }

        public void PickUp(Item item) { }
        public void Equip(Item item) { } //???
    }

    public class Item
    {
    }

    public struct OffensiveSpell //DefensiveSpell
    {
        public string Name { get; }
        public object Type { get; }//??
    }

    public struct Spell
    {
        public string Name { get; }
        public object Type { get; }//??
    }

    public struct Effect
    {

    }

    public readonly struct Damage
    {
        public object Type { get; } //??
        public int Value { get; }
    }

    public readonly struct Experience
    {
        public int Level { get; }
        public int Value { get; }
        public int AttributePoints { get; }
    }

    public readonly struct Health
    {
        public int Current { get; }
        public int Max { get; }
    }

    public readonly struct Mana
    {
        public int Current { get; }
        public int Max { get; }
    }

    public readonly struct Attributes
    {
        public int Strength { get; }
        public int Dexterity { get; }
        public int Inteligence { get; }
    }

    public class Inventory
    {
        public int Gold { get; }
        public int Capacity { get; }
        //Current Weight
        //Add(Item item)
    }

    public class Equipment
    {
        public object BodyArmour { get; }
        public object Boots { get; }
        public object Gloves { get; }
        public object Helmet { get; }

        public object MainHand { get; }
        public object OffHand { get; }
    }

    public class SpellBook
    {
    }

    public readonly struct Resistances
    {
        public int Fire { get; }
        public int Ice { get; }
        public int Lightning { get; }
    }
}
