using Odysseus.DomainModel.GameMechanics.Items;
using System;

namespace Odysseus.DomainModel.GameMechanics.Inventory
{
    public class Equipment
    {
        public event EventHandler<EquipedEventArgs>? Equiped;

        private readonly Slot bodyArmour, boots, gloves, helmet, mainHand, offHand;
        
        public IItem BodyArmour => bodyArmour.Item;
        public IItem Boots => boots.Item;
        public IItem Gloves => gloves.Item;
        public IItem Helmet => helmet.Item;
        public IItem MainHand => mainHand.Item;
        public IItem OffHand => offHand.Item;

        public Equipment()
        {
            bodyArmour = new Slot();
            boots = new Slot();
            gloves = new Slot();
            helmet = new Slot();
            mainHand = new Slot();
            offHand = new Slot();
        }

        public void Equip(IItem item)
        {
            if(item is BodyArmor)
            {
                if(bodyArmour.IsEmpty)
                {
                    var oldItem = bodyArmour.Item;
                    bodyArmour.Item = item;
                    Equiped?.Invoke(this, new EquipedEventArgs());
                } else
                {
                    bodyArmour.Item = item;
                    Equiped?.Invoke(this, new EquipedEventArgs());
                }
            }
        }

        public Weight Weight =>
            BodyArmour.Weight +
            Boots.Weight +
            Gloves.Weight +
            Helmet.Weight +
            MainHand.Weight +
            OffHand.Weight ;
    }
}