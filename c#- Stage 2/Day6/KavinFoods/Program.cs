using BillingLibrary.Models;
using BillingLibrary.Repository;

namespace KavinFoods
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Bill mybill = new Bill() { No = 2, Vendor = "Mukul Chole Bhature", GrossAmount = 359 };
            BillRepository _repo = new BillRepository();
            _repo.AddBill(mybill);
            foreach (Bill bill in _repo.GetAllBills())
            {
                Console.WriteLine(bill.No + bill.Vendor + bill.BillDate + bill.GrossAmount);
            }
            Bill newbill = new Bill() { No = 2, Vendor = "Mukul Chat Bhandar", GrossAmount = 100 };
            _repo.UpdateBill(2, newbill);
            foreach (Bill bill in _repo.GetAllBills())
            {
                Console.WriteLine(bill.No + bill.Vendor + bill.BillDate + bill.GrossAmount);
            }
            //_repo.DeleteBill(2);
        }
    }
}
