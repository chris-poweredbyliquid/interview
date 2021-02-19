using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using LiquidApi.Controllers.Requests;
using LiquidApi.Controllers.Responses;
using LiquidApi.Services;
using Microsoft.AspNetCore.Cors;

namespace LiquidApi.Controllers
{
    [ApiController]
    [EnableCors(Startup.AllowAnyOrigins)]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(
            ILogger<CustomerController> logger,
            ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost("searches")]
        public async Task<ActionResult<Customer>> SearchCustomerAsync(SearchCustomer searchCustomer)
        {
            var customer = await _customerService.GetCustomerByFirstAndLastNameAsync(searchCustomer.FirstName, searchCustomer.LastName);

            if (customer == null)
            {
                _logger.LogWarning($"Customer '{searchCustomer.FirstName} {searchCustomer.LastName}' not found.");
                return NotFound();
            }

            _logger.LogInformation($"Customer {searchCustomer.FirstName} {searchCustomer.LastName} successfully retrieved.");
            return Ok(customer);
        }


        [HttpGet("addresses/{countryName}/searches")]
        public async Task<ActionResult<List<Address>>> SearchAddressAsync(string countryName)
        {
            var addresses = await _customerService.GetAddressesByCountryAsync(countryName);

            if (!addresses.Any())
            {
                _logger.LogWarning($"No addresses found for '{countryName}' country.");
                return NotFound();
            }

            _logger.LogWarning($"Successfully retrieved addresses for '{countryName}' country.");
            return Ok(addresses);
        }
    }
}
