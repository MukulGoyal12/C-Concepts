using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Tomato.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId {  get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now ;
        public double GrossAmount {  get; set; }

        //Navigation Property - ForeignKey
        public virtual Customer Customer { get; set; }
    }
}
