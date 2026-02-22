using System.Net;
using System.Text.RegularExpressions;
using DnsClient;

namespace Silofy.Domain.Shared.ValueObjects;

public partial record Email
{
    public string Address { get; }
    private static readonly Regex EmailRegex = MyRegex();
    
    protected Email() { }    
    private Email(string address) => Address = address;

    public static implicit operator string(Email email) => email.Address;
    
    public static Email Create(string address)
    {
        Validate(address);
        return new Email(address.ToLower().Trim());
    }
    
    public string GetDomain() => Address[(Address.IndexOf('@') + 1)..];
    
    private static void Validate(string address)
    {
        if(!EmailRegex.IsMatch(address))
            throw new FormatException("Email address is not valid");
        
        var domain = address[(address.IndexOf('@') + 1)..];

        try
        {
            var hostAddresses = Dns.GetHostAddresses(domain);  
        }
        catch (Exception)
        {
            throw new FormatException("Email address is not valid");
        }

        var client = new LookupClient();
        var result = client.Query(domain, QueryType.MX);
        
        if(result.Answers.Count == 0)
            throw new FormatException("Email address is not valid");
    }
    
    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    private static partial Regex MyRegex();
}