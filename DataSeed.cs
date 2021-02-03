using LiquidApi.Context;
using LiquidApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidApi
{
    public static class DataSeed
    {
        public static void AddSeedData(LiquidApiContext context)
        {
            Customer chris = new Customer
            {
                EmailAddress = "christopher@test.com",
                FirstName = "Christopher",
                LastName = "Walken",
                Address = new Address
                {
                    City = "Beverly Hills",
                    Country = "USA",
                    Line1 = "363 Copa De Oro Rd",
                    PostalCode = "90210",
                    StateOrProvince = "CA"
                }
            };

            Customer brooke = new Customer
            {
                EmailAddress = "brooke@test.com",
                FirstName = "Brooke",
                LastName = "Shields",
                Address = new Address
                {
                    City = "New York",
                    Country = "USA",
                    Line1 = "225 W 10th St",
                    PostalCode = "10014",
                    StateOrProvince = "NY"
                }
            };

            context.Customers.Add(chris);
            Console.WriteLine($"[SEED] Added customer: {JsonConvert.SerializeObject(chris, Formatting.Indented)}");
            context.Customers.Add(brooke);
            Console.WriteLine($"[SEED] Added customer: {JsonConvert.SerializeObject(brooke, Formatting.Indented)}");
        }
    }
}
