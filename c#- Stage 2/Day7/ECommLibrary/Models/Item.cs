using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommLibrary.Models;

//Ye sare attributes isme dalne theek nhi h islie Context me OnModelCreating me dalo

public partial class Item            //POCO(plain old csharp object) Class
{
    public int ItemId { get; set; }

    //[Column(TypeName ="varchar(40)")]      By default Nvarchar(Max) krta h migration use varchar(40) me convert kia
    public string? ItemName { get; set; }

    //[NotMapped]    Column me mt dalna
    public double? Price { get; set; }

    public int? QtyinStock { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
