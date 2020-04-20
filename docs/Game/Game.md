# Game
Fantasy concept, Hero travels through the maps and fights with monster
Earns Experiens which generates Skill Points

# Domain Models
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

