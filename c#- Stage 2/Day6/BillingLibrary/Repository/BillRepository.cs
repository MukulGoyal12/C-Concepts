using System;
using System.Collections.Generic;
using System.Text;
using BillingLibrary.Models;

namespace BillingLibrary.Repository
{
    public class BillRepository
    {
        //ado-c
        //Dapper
        //Entity Framework -- partial info provided , kuch code nahi likhna jyada bs direction dikhani h hme.

        BillContext _context= new BillContext();

        public void AddBill(Bill b)
        {
            _context.Bills.Add(b);       //Change Detection -- Added , Detached , Deleted , Modified
            _context.SaveChanges();
        }

        //add this to repository class
        public List<Bill> GetAllBills()
        {
            return _context.Bills.ToList();//will execute the select statement
        }

        public void UpdateBill(int no, Bill b)
        {
            Bill temp = _context.Bills.FirstOrDefault(x => x.No == no);
            if (temp != null)
            {
                temp.Vendor = b.Vendor;
                temp.GrossAmount = b.GrossAmount;
                _context.SaveChanges();  //will execute update sql command
            }
        }

        public void DeleteBill(int billNo)
        {
            Bill temp = _context.Bills.FirstOrDefault(x => x.No == billNo);
            if (temp != null)
            {
                _context.Remove(temp);
                _context.SaveChanges();
            }
        }

    }
}
