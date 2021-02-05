using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiquidApi.Controllers.Responses;
using LiquidApi.Factories;
using LiquidApi.Interfaces;
using LiquidApi.Repositories;

namespace LiquidApi.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly CustomerRepository _customerRepository;

        private readonly CustomerFactory _customerFactory;

        public CustomerService(
            CustomerRepository customerRepository,
            CustomerFactory customerFactory
        )
        {
            _customerFactory = customerFactory;
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Address>> GetAddressesByCountry(string countryName)
        {
            var countries = await _customerRepository.GetAddressByCountry(countryName);

            return countries.Select(a => _customerFactory.GetAddress(a)).ToList();
        }

        public async Task<Customer> GetCustomerByFirstAndLastName(string firstName, string lastName)
        {
            var customer = await _customerRepository.GetCustomerByFirstAndLastName(firstName, lastName);

            return _customerFactory.GetCustomer(customer);
        }
    }
}
