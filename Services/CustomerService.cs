using System.Collections.Generic;
using System.Threading.Tasks;

using LiquidApi.Controllers.Responses;
using LiquidApi.Factories;
using LiquidApi.Repositories;

namespace LiquidApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFactory _customerFactory;

        public CustomerService(
            ICustomerRepository customerRepository,
            ICustomerFactory customerFactory)
        {
            _customerRepository = customerRepository;
            _customerFactory = customerFactory;
        }

        public async Task<List<Address>> GetAddressesByCountryAsync(string countryName)
        {
            var addresses = await _customerRepository.GetAddressesByCountryAsync(countryName);

            return addresses.ConvertAll(x => _customerFactory.CreateAddress(x));
        }

        public async Task<Customer> GetCustomerByFirstAndLastNameAsync(string firstName, string lastName)
        {
            var customer = await _customerRepository.GetCustomerByFirstAndLastNameAsync(firstName, lastName);

            return _customerFactory.CreateCustomer(customer);
        }
    }
}
