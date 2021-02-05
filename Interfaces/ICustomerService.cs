using System.Collections.Generic;
using System.Threading.Tasks;
using LiquidApi.Controllers.Responses;

namespace LiquidApi.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Address>> GetAddressesByCountry(string countryName);

        Task<Customer> GetCustomerByFirstAndLastName(string firstName, string lastName);
    }
}
