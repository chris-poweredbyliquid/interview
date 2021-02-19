using LiquidApi.Context;
using LiquidApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiquidApi.Repositories
{
    public class CustomerRepository
    {
        private readonly LiquidApiContext context;

        public CustomerRepository(LiquidApiContext context)
        {
            this.context = context;
        }

        public List<Address> GetAddressByCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentException(nameof(country));
            }

            return this.context.Addresses
                .Where(x => x.Country.Equals(country, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Customer GetCustomerByFirstAndLastName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException(nameof(lastName));
            }

            return this.context.Customers
                .SingleOrDefault(x => x.FirstName == firstName && x.LastName == x.LastName);
        }

        public Customer GetCustomerById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }

            return this.context.Customers
                .SingleOrDefault(x => x.Id == id);
        }
    }
}
