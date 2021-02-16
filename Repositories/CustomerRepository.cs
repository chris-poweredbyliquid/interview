using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LiquidApi.Context;
using LiquidApi.Models;

namespace LiquidApi.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly LiquidApiContext _context;

        public CustomerRepository(LiquidApiContext context)
        {
            this._context = context;
        }

        public async Task<List<Address>> GetAddressByCountry(string coutry)
        {
            return await _context.Addresses
                .Where(a => coutry.Equals(a.Country, StringComparison.InvariantCultureIgnoreCase))
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByFirstAndLastName(string firstName, string lastName)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c =>
                    firstName.Equals(c.FirstName, StringComparison.InvariantCultureIgnoreCase)
                    && lastName.Equals(c.LastName, StringComparison.InvariantCultureIgnoreCase)
                );
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
