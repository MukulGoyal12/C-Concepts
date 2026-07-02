using System;
using System.Collections.Generic;
using System.Text;

namespace Medical_Inventory
{
    internal class MedicalEquipmentInventorySystem
    {
        List<MedicalEquipment> Equipments = new();

        public void AddEquipment(string equipmentName, string manufacturer, int quantity, double unitCost)
        {
            foreach(MedicalEquipment equipments in Equipments)
            {
                if(equipments.EquipmentName == equipmentName && equipments.Manufacturer == manufacturer)
                {
                    Console.WriteLine("Equipment already exists.");
                    return;
                }
            }
            Equipments.Add(new MedicalEquipment(equipmentName, manufacturer, quantity, unitCost));
            Console.WriteLine("Equipment added successfully.");
        }

        public MedicalEquipment GetEquipmentDetails(string equipmentName, string manufacturer)
        {
            foreach (MedicalEquipment equipments in Equipments)
            {
                if (equipments.EquipmentName == equipmentName && equipments.Manufacturer == manufacturer)
                {
                    Console.WriteLine(equipments);
                    return equipments;
                }
            }

            throw new EquipmentNotFoundException("Equipment not found.");
        }

        public void RemoveEquipment(string equipmentName, string manufacturer)
        {
            foreach (MedicalEquipment equipments in Equipments)
            {
                if (equipments.EquipmentName == equipmentName && equipments.Manufacturer == manufacturer)
                {
                    Equipments.Remove(equipments);
                    Console.WriteLine("Equipment removed successfully.");
                    return;
                }
            }

            throw new EquipmentNotFoundException("Equipment not found.");
        }

    }
}
