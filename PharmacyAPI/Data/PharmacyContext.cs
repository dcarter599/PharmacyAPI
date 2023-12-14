using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Models;

namespace PharmacyAPI.Data
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options)
            : base(options)
        {
        }

        public DbSet<Pharmacy> Pharmacies { get; set; }
    }
}
