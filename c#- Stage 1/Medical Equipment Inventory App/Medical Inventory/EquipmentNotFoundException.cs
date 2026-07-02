using System;
using System.Collections.Generic;
using System.Text;

namespace Medical_Inventory
{
    internal class EquipmentNotFoundException:Exception
    {
        public EquipmentNotFoundException(string message) : base(message)
        {

        }
    }
}
