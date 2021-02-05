using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiquidApi.Context;
using Microsoft.EntityFrameworkCore;
using Address = LiquidApi.Models.Address;
using Customer = LiquidApi.Models.Customer;

namespace LiquidApi.Repositories
{
    public class CustomerRepository
    {
        private readonly LiquidApiContext _liquidApiContext;

        public CustomerRepository(LiquidApiContext liquidApiContext)
        {
            _liquidApiContext = liquidApiContext;
        }

        public async Task<IEnumerable<Address>> GetAddressByCountry(string country)
        {
            return await _liquidApiContext.Addresses
                .Where(a =>
                    string.Equals(a.Country, country, StringComparison.OrdinalIgnoreCase)
                )
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByFirstAndLastName(string firstName, string lastName)
        {
            return await _liquidApiContext.Customers
                .FirstOrDefaultAsync(a =>
                    string.Equals(a.FirstName, firstName, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(a.LastName, lastName, StringComparison.OrdinalIgnoreCase)
                );
        }

        public async Task<Customer> GetCustomerById(Guid guid)
        {
            return await _liquidApiContext.Customers
                .FirstOrDefaultAsync(a => a.Id == guid);
        }
    }
}
