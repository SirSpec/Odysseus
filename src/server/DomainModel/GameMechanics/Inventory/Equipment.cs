using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Equipment
    {
        public event EventHandler<EquipedEventArgs>? Equiped;

        //TODO: turn into list
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
        //turn into list
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

        public double Weight =>
            BodyArmour?.Weight ?? 0.0 +
            Boots?.Weight ?? 0.0 +
            Gloves?.Weight ?? 0.0 +
            Helmet?.Weight ?? 0.0 +
            MainHand?.Weight ?? 0.0 +
            OffHand?.Weight ?? 0.0;
    }
}