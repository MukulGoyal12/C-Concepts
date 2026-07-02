using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstate.Models;

namespace RealEstate.Repository
{
    public class ZaminRepository : IZaminRepository
    {
        List<Zamin> database = new();

        public bool AddZamin(Zamin z)
        {
            database.Add(z);
            return true;
        }
        public bool DeleteZamin(int id)
        {
            return true;
        }
        public Zamin GetZamin(int id)
        {
            return database.Where((z) => z.Id == id).FirstOrDefault();
        }
        public List<Zamin> GetAllZamin()
        {
            return database.ToList();
        }
        public bool UpdateZamin()
        {
            return true;
        }

    }
}
