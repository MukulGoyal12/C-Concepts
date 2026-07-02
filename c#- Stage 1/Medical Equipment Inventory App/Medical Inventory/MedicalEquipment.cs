using System;
using System.Collections.Generic;
using System.Text;

namespace Medical_Inventory
{
    internal class MedicalEquipment
    {
        internal string EquipmentName { get; set; }
        internal string Manufacturer { get; set; }
        internal int Quantity { get; set; }
        internal double UnitCost { get; set; }

        public MedicalEquipment(string equipmentName, string manufacturer, int quantity, double unitCost)
        {
            EquipmentName=equipmentName;
            Manufacturer=manufacturer;
            Quantity=quantity;
            UnitCost=unitCost;
        }

        public override string ToString()
        {
            return $"EquipmentName:{EquipmentName} Manufacturer:{Manufacturer} Quantity:{Quantity} UnitCost:{UnitCost}";
        }

    }
}
