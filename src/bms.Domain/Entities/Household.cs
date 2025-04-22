using bms.Domain.Common;

namespace bms.Domain.Entities;

public class Household
{
    public Guid Id { get; private set; }
    public string HouseholdName { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string Barangay { get; private set; } = null!;
    public string District { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Region { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public string Zipcode { get; private set; } = null!;
    public AuditInfo AuditInfo { get; private set; }
    
    private Household(Guid id, 
        string householdName, 
        string street, 
        string barangay,
        string district,
        string city,
        string region,
        string country,
        string zipcode,
        AuditInfo auditInfo)
    {
        Id = id;
        HouseholdName = householdName;
        Street = street;
        Barangay = barangay;
        District = district;
        City = city;
        Region = region;
        Country = country;
        Zipcode = zipcode;
        AuditInfo = auditInfo;
    }

    public static Household Create(Guid id, 
        string householdName, 
        string street, 
        string barangay,
        string district,
        string city,
        string region,
        string country,
        string zipcode)
    {
        var auditInfo = AuditInfo.ProcessCreate();
        var household = new Household(id, 
            householdName, 
            street, 
            barangay, 
            district, 
            city, 
            region, 
            country, 
            zipcode,
            auditInfo);
        
        return household;
    }
}