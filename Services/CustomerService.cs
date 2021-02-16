using System;
using System.Threading.Tasks;
using LiquidApi.Repositories;
using LiquidApi.Controllers.Responses;
using LiquidApi.Factories;
using System.Linq;
using System.Collections.Generic;

namespace LiquidApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFactory _customerFactory;

        public CustomerService(ICustomerRepository customerRepository, ICustomerFactory customerFactory)
        {
            this._customerRepository = customerRepository;
            this._customerFactory = customerFactory;
        }

        public async Task<List<Address>> GetAddressesByCountry(string countryName)
        {
            var addresses = await _customerRepository.GetAddressByCountry(countryName);

            return addresses
                .Select(a => _customerFactory.GetAddress(a))
                .ToList();
        }

        public async Task<Customer> GetCustomerByFirstAndLastName(string firstName, string lastName)
        {
            var customer = await _customerRepository.GetCustomerByFirstAndLastName(firstName, lastName);

            return _customerFactory.GetCustomer(customer);
        }
    }
}
