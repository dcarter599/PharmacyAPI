using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Models;
using PharmacyAPI.Services;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PharmacyController : ControllerBase
    {

        private readonly ILogger<PharmacyController> _logger;
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(ILogger<PharmacyController> logger, IPharmacyService pharmacyService)
        {
            _logger = logger;
            _pharmacyService = pharmacyService;
        }

        [HttpGet(Name = "GetPharmacies")]
        public async Task<IActionResult> GetAll()
        {
            var pharmacies = _pharmacyService.GetAll();
            return Ok(pharmacies);
        }

        [HttpGet("{Id}", Name = "GetPharmacy")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var pharmacy = await _pharmacyService.Get(Id);
                if(pharmacy is null)
                    return NotFound("Could not find pharmacy");
                else 
                    return Ok(pharmacy);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _logger.LogCritical(ex, ex.Message);
                return ValidationProblem("Invalid Id given");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                return Problem("Invalid Id given");
            }
        }

        [HttpPatch(Name = "UpdatePharmacy")]
        public async Task<IActionResult> Update([FromBody] Pharmacy pharmacy)
        {
            try
            {
                var updated = await _pharmacyService.Update(pharmacy.Id, pharmacy);
                if(!updated)
                    return BadRequest();
                else
                    return Ok();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _logger.LogCritical(ex, ex.Message);
                return ValidationProblem("Invalid Id given");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                return Problem("Invalid Id given");
            }
        }
    }
}