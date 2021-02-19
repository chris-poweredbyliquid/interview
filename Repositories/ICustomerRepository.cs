using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using LiquidApi.Models;

namespace LiquidApi.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Address>> GetAddressesByCountryAsync(string countryName);
        Task<Customer> GetCustomerByFirstAndLastNameAsync(string firstName, string lastName);
        Task<Customer> GetCustomerByIdAsync(Guid id);
    }
}