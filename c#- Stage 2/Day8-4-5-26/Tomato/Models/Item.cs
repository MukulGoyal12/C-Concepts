using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tomato.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price {  get; set; }
        public int QtyInStock {  get; set; }
    }
}
