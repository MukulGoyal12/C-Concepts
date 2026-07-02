using RealEstate.Repository;
using RealEstate.Services;
using RealEstate.Models;

namespace Casagrand

{

    internal class Program
    {

        static void Main(string[] args)

        {

            IZaminRepository _repo = new ZaminRepositoryDapper();

            ZaminService _service = new ZaminService(_repo);

            _service.AddZamin(new Zamin());

        }

    }

}