using Microsoft.AspNetCore.Mvc;
using Twiggy.Models;
using Twiggy.Repository;

namespace Twiggy.Controllers
{
    public class CustomerController : Controller
    {

        CustomerRepository repository=new CustomerRepository();
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        public IActionResult Add(Customer c)
        {
            if (repository.AddCustomer(c))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
