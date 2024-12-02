using ProtoBuf;

namespace BlazorBuilds.Contracts.Customers;

[ProtoContract]
public class CustomerSearchRequest
{
    [ProtoMember(1)] public string? CompanyName { get; set; }

    private CustomerSearchRequest() { }

    public CustomerSearchRequest(string? companyName) => CompanyName = companyName;

}

[ProtoContract]
public class CustomerSearchResponse
{
    [ProtoMember(1)] public IEnumerable<CustomerSearchResult> SearchResults { get; set; } = new List<CustomerSearchResult>();

    public CustomerSearchResponse(IEnumerable<CustomerSearchResult> searchResults) => SearchResults = searchResults;

    private CustomerSearchResponse() { }

}
