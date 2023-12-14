using PharmacyAPI.Models;
using PharmacyAPI.Repository;

namespace PharmacyAPI.Services
{
    public class PharmacyService : IPharmacyService
    {
        private readonly ILogger<PharmacyService> _logger;
        private readonly IEntityRepository<Pharmacy> _repository;

        public PharmacyService(ILogger<PharmacyService> logger, IEntityRepository<Pharmacy> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Pharmacy?> Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            var pharmacy = await _repository.GetAsync(id);
            if (pharmacy is null)
            {
                _logger.LogWarning("Could not find pharmacy with Id of {id}", id);
            }

            return pharmacy;
        }

        public List<Pharmacy> GetAll()
        {
            var pharmacies = _repository.GetAll();

            return pharmacies;
        }

        public async Task<bool> Update(int id, Pharmacy pharmacy)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            var existingPharmacy = await _repository.GetAsync(id);
            if (existingPharmacy is null)
            {
                _logger.LogWarning("Could not find pharmacy to update with Id of {id}", id);
                return false;
            }

            await _repository.UpdateAsync(existingPharmacy, pharmacy);
            return true;
        }
    }
}
