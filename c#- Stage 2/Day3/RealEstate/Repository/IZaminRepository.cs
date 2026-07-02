using RealEstate.Models;

namespace RealEstate.Repository
{
    public interface IZaminRepository
    {
        bool AddZamin(Zamin z);
        bool DeleteZamin(Zamin z);
        List<Zamin> GetAllZamin();
        Zamin GetZamin(int id);
        bool UpdateZamin();
    }
}