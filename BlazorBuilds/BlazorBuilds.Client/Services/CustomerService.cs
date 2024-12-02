using BlazorBuilds.Contracts.Customers;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace BlazorBuilds.Client.Services;

public class CustomerService
{
    private readonly IGrpcCustomerService _customerService;

    /*
        * I have injected the channel as I like to do it this way.
        * 
        * You can create the channel and service in the program file if you prefer, and have the IGrpcCustomerService injected
    */
    public CustomerService(GrpcChannel channel) => _customerService = channel.CreateGrpcService<IGrpcCustomerService>();
    /*
        * I am trying to keep things super simple so no error handling, which I do in a functional way with extensions.
        * I do not want to confuse by doing what and how I normally do things. If you want a glimpse of that
        * go and look at my demo code in my Flow repository: https://github.com/code-dispenser/Flow
    */
    public async Task<CustomerSearchResponse> CustomerSearch(string? customerID)

        => await _customerService.CustomerSearch(new CustomerSearchRequest(customerID));
}
