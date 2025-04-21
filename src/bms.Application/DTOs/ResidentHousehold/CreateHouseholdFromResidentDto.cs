namespace bms.Application.DTOs.ResidentHousehold;

public class CreateHouseholdFromResidentDto
{
    public List<Guid> HouseholdIds { get; set; } = new List<Guid>();
}