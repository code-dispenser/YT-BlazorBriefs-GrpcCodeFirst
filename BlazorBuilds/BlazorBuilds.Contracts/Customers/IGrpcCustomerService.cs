using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace BlazorBuilds.Contracts.Customers;

[Service]
public interface IGrpcCustomerService
{
    [Operation]
    Task<CustomerSearchResponse> CustomerSearch(CustomerSearchRequest instruction, CallContext context = default);
}