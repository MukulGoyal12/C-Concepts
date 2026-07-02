using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Tomato.Models;

namespace Tomato.Repository
{
    public class ItemRepository
    {
        private readonly TomatoContext _context;

        public ItemRepository()
        {
            _context = new TomatoContext();
        }

        public void SetQuantity(int id ,int quantity)
        {
            //update one row
            //var find = _context.Items.Find(10);
            //find.QtyInStock = quantity;
            //_context.SaveChanges();

            //Let say update all rows
            _context.Items.Where(item=>true).ExecuteUpdate(props=>props.SetProperty(p=>p.QtyInStock, quantity));

            //_context.Database.ExecuteSqlRaw("Select * from items where id=1");
            //_context.Database.ExecuteSql($"Select * from items where id={id}");
        }
    }
}
