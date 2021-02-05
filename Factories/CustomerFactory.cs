using Address = LiquidApi.Controllers.Responses.Address;
using Customer = LiquidApi.Controllers.Responses.Customer;

namespace LiquidApi.Factories
{
    public class CustomerFactory
    {
        public Address GetAddress(Address address)
        {
            return new Address
            {
                Id = address.Id,
                Line1 = address.Line1,
                Line2 = address.Line2,
                City = address.City,
                StateOrProvince = address.StateOrProvince,
                Country = address.Country,
                PostalCode = address.PostalCode
            };
        }

        public Customer GetCustomer(Customer customer)
        {
            return new Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress
            };
        }
    }
}
