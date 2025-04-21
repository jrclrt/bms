using bms.Domain.Primitives;

namespace bms.Domain.Entities;

public class Household : Entity
{
    private Household(Guid id, 
        string householdName, 
        string street, 
        string barangay,
        string district,
        string city,
        string region,
        string country,
        string zipcode)
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
    }
    
    public string HouseholdName { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string Barangay { get; private set; } = null!;
    public string District { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Region { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public string Zipcode { get; private set; } = null!;

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
        var household = new Household(id, 
            householdName, 
            street, 
            barangay, 
            district, 
            city, 
            region, 
            country, 
            zipcode);
        
        return household;
    }
}