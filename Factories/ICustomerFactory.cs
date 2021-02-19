using LiquidApi.Models;

using CustomerResponse = LiquidApi.Controllers.Responses.Customer;
using AddressResponse = LiquidApi.Controllers.Responses.Address;

namespace LiquidApi.Factories
{
    public interface ICustomerFactory
    {
        AddressResponse CreateAddress(Address address);
        CustomerResponse CreateCustomer(Customer customer);
    }
}