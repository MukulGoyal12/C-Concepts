using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BillingLibrary.Models
{
    public class Bill
    {
        [Key]                //No ke upr kia , means ye ab table bante time primary key ban jaegi.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int No { get; set; }
        public string Vendor { get; set; }
        public int GrossAmount { get; set; }
        public DateTime? BillDate { get; set; }=DateTime.Now;
    }
}
