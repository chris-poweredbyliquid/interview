using System.Collections.Generic;
using System.Threading.Tasks;

using LiquidApi.Controllers.Responses;

namespace LiquidApi.Services
{
    public interface ICustomerService
    {
        Task<List<Address>> GetAddressesByCountryAsync(string countryName);
        Task<Customer> GetCustomerByFirstAndLastNameAsync(string firstName, string lastName);
    }
}