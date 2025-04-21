namespace bms.Domain.Entities;

public class ResidentHousehold
{
    internal ResidentHousehold(Guid id, Guid residentId, Guid householdId)
    {
        Id = id;
        ResidentId = residentId;
        HouseholdId = householdId;
    }
    
    public Guid Id { get; private set; }
    public Guid ResidentId { get; private set; }
    public Guid HouseholdId { get; private set; }
}