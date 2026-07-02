using System;
using System.Collections.Generic;
using System.Text;
using ECommLibrary.Models;

namespace EcommerceLibrary.Repository
{
    public class ItemRepository<T>
    {
        EcommerceContext context = new EcommerceContext();
        public void AddData(T item)
        {
            if (item is Item it)
                context.Items.Add(it);
            else if (item is Order ord)
                context.Orders.Add(ord);
            else if (item is OrderItem oi)
                context.OrderItems.Add(oi);
            context.SaveChanges();
        }
    }
}