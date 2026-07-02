using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tomato.Models
{
    public class Customer
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName ="varchar(30)")]   //By default nullable hai
        [Required]
        public string Name { get; set; }   //nvarchar(max ie 4000) by default but we dont want it to we use

        [MinLength(1)]
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
