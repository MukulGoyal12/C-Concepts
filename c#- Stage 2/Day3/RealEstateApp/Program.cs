using RealEstate.Models;
using RealEstate.Repository;
using RealEstate.Services;
namespace RealEstateApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ZaminRepository zaminRepository = new ZaminRepository();
            ZaminService s = new ZaminService(zaminRepository);
        }
    }
}