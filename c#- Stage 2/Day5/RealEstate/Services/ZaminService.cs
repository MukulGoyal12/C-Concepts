using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstate.Models;
using RealEstate.Repository;

namespace RealEstate.Services
{
    public class ZaminService
    {
        private readonly IZaminRepository _repository;
        public ZaminService(IZaminRepository repo)
        {
            _repository = repo;
        }
        //public double CalculatePrice(Zamin z)
        //{
        //   if(z.Area==null ||z.Area<=0) 
        //        throw new NullReferenceException();
        //    switch (z.Location)
        //    {
        //        case "Chennai":
        //            return z.Area * 1200;
        //        case "Hyderabad":
        //            return z.Area * 3000;
        //        case "Bangalore":
        //            return z.Area * 11000;
        //    }
        //    return 0;
        //}
        public bool AddZamin(Zamin z)
        {
            if(z == null) throw new ArgumentNullException(nameof(z));
            if (_repository.AddZamin(z))
                return true;
            return false;
        }
    }
}
