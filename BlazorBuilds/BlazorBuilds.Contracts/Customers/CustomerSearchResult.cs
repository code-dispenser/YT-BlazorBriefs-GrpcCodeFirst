using ProtoBuf;

namespace BlazorBuilds.Contracts.Customers;

[ProtoContract]
public record class CustomerSearchResult
{
    [ProtoMember(1)] public string CustomerID   { get; } = default!;
    [ProtoMember(2)] public string CompanyName  { get; } = default!;
    [ProtoMember(3)] public string ContactName  { get; } = default!;
    [ProtoMember(4)] public string ContactTitle { get; } = default!;

    private CustomerSearchResult() { }

    public CustomerSearchResult(string customerID, string companyName, string contactName, string contactTitle)
    {
        CustomerID      = customerID;
        CompanyName     = companyName;
        ContactName     = contactName;
        ContactTitle    = contactTitle;
    }
}
