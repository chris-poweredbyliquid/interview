using System.Threading.Tasks;
using System.Collections.Generic;
using LiquidApi.Controllers.Responses;

namespace LiquidApi.Services
{
    interface ICustomerService
    {
        Task<List<Address>> GetAddressesByCountry(string countryName);

        Task<Customer> GetCustomerByFirstAndLastName(string firstName, string lastName);
    }
}
