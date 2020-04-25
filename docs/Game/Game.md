# Game
Fantasy themed Rougelike game.
Hero travels through the maps and fights with monsters.

# Domain Models
## Player Character Statistics
- Value Object which represents statistics of the Player Character.
- Statistics have Base Statistics and Total Statistics
- Total Statistics are calculated based on the Base Statistics and applied modifiers.

## Main
- Level
- Attributes
- Health
- Mana

### Attributes
Strength, Dexterity and Inteligence of the Player Character
- Cannot be less than 0
- Interaction: Changed based on a number of Skill Points spent on each of them

### Health
- Health represents the total number of Damage that can be dealt to the Player Character,
- Health cannot be less then 0.
- Base Health is calculated based on a Level and a Strength of the Player Character:
    - HealthPerLevel * Level + Strength where HealthPerLevel = 12
- Health is calculated based the Base Health and Health Modifiers
    - Health Modifiers come from the Equipment

### Mana
- Mana represents the total number of points that Player Character uses to cast Spells,
- Mana cannot be less then 0.
- Base Mana is calculated based on a Level and a Inteligence of the Player Character:
    - ManaPerLevel * Level + Inteligence where ManaPerLevel = 6
- Mana is calculated based the Base Mana and Mana Modifiers
    - Mana Modifiers come from the Equipment

## Offence
Base Damage is a sum of Weapons Damage that are equiped by the Character multipled by the Attributes.
Overall Damage is based on Base Damage and Damage Modifiers
- Melee Damage
    - Damage = Weapon Damage * Strength
- Ranged Damage
    - Damage = Weapon Damage * Dexterity
- Elemental Damage: Fire, Ice, Lightning
    - Damage = Weapon Damage * Inteligence

## Defence
- Base Armor against Physical Damage
    - Sum of Armor of Equiped Armor :P
- Base Resistances against Elemental Damage
    - Sum of Resistance Modifiers of Equiped Items

### Experience
Number of Experience Points and a Level of the Player Character
- Experience Points cannot be less than 0
- Level cannot be less than 1
- Level is calculated based on the Experience Points
    - Math.Floor((25 + Math.Sqrt(625 + 100 * Experience)) / 50)
- Interaction: Experience Points can be changed when a Player Character kills a monster

### Skill Points
Points that are used to increase a value of an attribute.
- Points are increased when the Player Characters Levels Up
- Each Level Up increases Skill Points by 1

## Inventory
### Equipment

### Backpack

## Player Character
### Properties
- Name
- Level
- Experience
- Attribute Points
- Attributes: Strenght/Dexterity/Inteligence
- Spell Book: Spells
- Health
    - Current 
    - Max
    - IsDead?
- Mana
    - Current
    - Max
- Inventory
    - Gold
    - Items
    - Current Weight
    - Max Weight Capacity
- Equipment
    - Armor: Shield, Helment, Boots, Gloves, Chest
    - Weapons: Sword, Two Swords, Magic Axe
- Resistances: Fire, Ice, Lightning

### Actions do we really have these actions?
- Attack
    - Weapon
    - Spell?
- Choose a spell from the Spellbook and use it
- Use Spell/Skills: fireball/Heal
- Pick up and item and add to inventory
- Learn a spell
- Incrase attribute
- BeDamaged
- GainExperience
- Equip

# Domain Service
- Statistics
- Damage => Sum of all Weapon Damage ?
- Armor => Sum of all Armors ?

# Events
- Leveled up
- Died
- Killed a monster?

# User interface
- Attack
    - Weapon
    - Offensive Spell/Skill
- Use Spell/Skills: Heal
- Pick up and item and add to inventory
- Use sth
- Open/Close: Doors

