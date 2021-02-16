using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiquidApi.Models;

namespace LiquidApi.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Address>> GetAddressByCountry(string country);

        Task<Customer> GetCustomerByFirstAndLastName(string firstName, string lastName);

        Task<Customer> GetCustomerById(Guid id);
    }
}
