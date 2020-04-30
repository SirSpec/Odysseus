using Odysseus.DomainModel.GameMechanics.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics.Inventory
{
    public class Equipment
    {
        public event EventHandler<EquipedEventArgs>? Equiped;
        
        //Chest, Boots, Gloves, Helmet, MainHand, OffHand
        private readonly IList<Slot> slots;
        public IEnumerable<IEquipable> EquipedItems => slots.Where(slot => !slot.IsEmpty).Select(slot => slot.Item);
        
        public Equipment() =>
            slots = new List<Slot>();

        public void Equip(IEquipable item)
        {
            if(EquipedItems.Any(item => item.Type == item.Type))
            {
                var oldItem = slots.First().Item;
                slots.First().Item = item;
                Equiped?.Invoke(this, new EquipedEventArgs());
            }
            else
            {
                slots.Add(new Slot { Item = item });
                Equiped?.Invoke(this, new EquipedEventArgs());
            }
        }

        public Weight Weight =>
            EquipedItems.Aggregate(Weight.Zero, (seed, next) => seed += next.Weight);
    }
}