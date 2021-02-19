using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using LiquidApi.Context;
using LiquidApi.Models;

namespace LiquidApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LiquidApiContext _context;

        public CustomerRepository(LiquidApiContext context)
        {
            this._context = context;
        }

        public async Task<List<Address>> GetAddressesByCountryAsync(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
            {
                throw new ArgumentException(nameof(countryName));
            }

            return await this._context.Addresses
                .Where(x => x.Country.Equals(countryName, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByFirstAndLastNameAsync(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException(nameof(lastName));
            }

            return await _context.Customers
                .SingleOrDefaultAsync(x => x.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    x.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }

            return await _context.Customers
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
