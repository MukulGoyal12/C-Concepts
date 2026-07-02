using System;
using System.Collections.Generic;

namespace ECommLibrary.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? CustomerName { get; set; }

    public double? GrossAmount { get; set; }

    public DateTime? Orderdate { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
