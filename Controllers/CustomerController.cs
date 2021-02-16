using LiquidApi.Controllers.Responses;
using LiquidApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiquidApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            this._logger = logger;
            this._customerService = customerService;
        }

        [HttpPost]
        [Route("searches")]
        public async Task<Customer> GetCustomerByFirstAndLastName(Requests.Customer customer)
        {
            return await _customerService.GetCustomerByFirstAndLastName(customer.FirstName, customer.LastName);
        }

        [HttpGet]
        [Route("addresses/{countryName}/searches")]
        public async Task<List<Address>> GetAddressByCountry(string countryName)
        {
            return await _customerService.GetAddressesByCountry(countryName);
        }
    }
}
