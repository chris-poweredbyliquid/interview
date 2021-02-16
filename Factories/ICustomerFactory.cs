using LiquidApi.Controllers.Responses;

namespace LiquidApi.Factories
{
    interface ICustomerFactory
    {
        Address GetAddress(Models.Address address);

        Customer GetCustomer(Models.Customer customer);
    }
}
