using BlazorBuilds.Contracts.Customers;
using ProtoBuf.Grpc;

namespace BlazorBuilds.GrpcServices;

public class GrpcCustomerService : IGrpcCustomerService
{
    public GrpcCustomerService() { } //Inject and get your usual stuff

    public async Task<CustomerSearchResponse> CustomerSearch(CustomerSearchRequest instruction, CallContext context = default)
    {
        /*
            * Use your injected dbcontext or query handler for the actual search etc.
        */
        List<CustomerSearchResult> searchResults = [new CustomerSearchResult("ALFKI", "Alfreds Futterkiste", "Maria Anders", "Sales Representative")];

        return await Task.FromResult(new CustomerSearchResponse(searchResults));
    }

}
