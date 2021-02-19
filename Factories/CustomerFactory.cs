using LiquidApi.Models;

using CustomerResponse = LiquidApi.Controllers.Responses.Customer;
using AddressResponse = LiquidApi.Controllers.Responses.Address;

namespace LiquidApi.Factories
{
    public class CustomerFactory : ICustomerFactory
    {
        public CustomerResponse CreateCustomer(Customer customer)
        {
            return customer == null
                ? null
                : new CustomerResponse
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    EmailAddress = customer.EmailAddress,
                    Address = CreateAddress(customer.Address),
                };
        }

        public AddressResponse CreateAddress(Address address)
        {
            return address == null
                ? null
                : new AddressResponse
                {
                    Id = address.Id,
                    City = address.City,
                    Country = address.Country,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    PostalCode = address.PostalCode,
                    StateOrProvince = address.StateOrProvince,
                };
        }
    }
}
