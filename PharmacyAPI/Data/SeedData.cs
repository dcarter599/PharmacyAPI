using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Models;

namespace PharmacyAPI.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PharmacyContext(serviceProvider.GetRequiredService<DbContextOptions<PharmacyContext>>()))
            {
                if (context.Pharmacies.Any())
                {
                    return;
                }
                context.Pharmacies.AddRange(
                    new Pharmacy
                    {
                        Name = "Joe's Pharmacy",
                        Address = "225 E Tracker Dr",
                        City = "Tucson",
                        State = "Arizona",
                        Zip = "45678",
                        FilledPrescriptions = 4,
                        Created = DateTime.Now.AddDays(-1),
                        LastUpdated = DateTime.Now,
                    },
                   new Pharmacy
                   {
                       Name = "CVS",
                       Address = "1 South Dr",
                       City = "Dallas",
                       State = "Texas",
                       Zip = "55609",
                       FilledPrescriptions = 2,
                       Created = DateTime.Now.AddDays(-50),
                       LastUpdated = DateTime.Now.AddDays(-50),
                   },
                    new Pharmacy
                    {
                        Name = "Walgreens",
                        Address = "5089 W Van St",
                        City = "Lewisville",
                        State = "Texas",
                        Zip = "23975",
                        FilledPrescriptions = 100,
                        Created = DateTime.Now.AddDays(-10),
                        LastUpdated = DateTime.Now.AddDays(-5),
                    },
                    new Pharmacy
                    {
                        Name = "Walmart",
                        Address = "100 Star Dr",
                        City = "Dallas",
                        State = "Texas",
                        Zip = "11234",
                        FilledPrescriptions = 200,
                        Created = DateTime.Now.AddDays(-100),
                        LastUpdated = DateTime.Now,
                    },
                    new Pharmacy
                    {
                        Name = "Billys",
                        Address = "52 S JFK Dr",
                        City = "Tampa",
                        State = "Florida",
                        Zip = "78976",
                        FilledPrescriptions = 13,
                        Created = DateTime.Now.AddDays(-30),
                        LastUpdated = DateTime.Now.AddDays(-28),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
