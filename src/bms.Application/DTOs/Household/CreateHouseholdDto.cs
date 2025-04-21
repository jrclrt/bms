namespace bms.Application.DTOs.Household;

public class CreateHouseholdDto
{
    public string HouseholdName { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string Barangay { get; set; } = null!;
    public string District { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Zipcode { get; set; } = null!;
}