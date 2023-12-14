using PharmacyAPI.Models;

namespace PharmacyAPI.Services
{
    public interface IPharmacyService
    {
        Task<Pharmacy?> Get(int id);
        List<Pharmacy> GetAll();
        Task<bool> Update(int id, Pharmacy pharmacy);
    }
}