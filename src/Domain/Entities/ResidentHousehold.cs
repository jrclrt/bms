namespace Domain.Entities;

public class ResidentHousehold : BaseModel
{
    public int ResidentId { get; set; }
    public Resident Resident { get; set; } = null!;
    public int HouseholdId { get; set; }
    public Household Household { get; set; } = null!;
}