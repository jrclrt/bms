using bms.Domain.Common;
using bms.Domain.Entities;

namespace bms.Domain.Aggregates.Residenthouseholds;

public class ResidentHousehold
{
    public Guid Id { get; private set; }
    public Guid ResidentId { get; private set; }
    public Guid HouseholdId { get; private set; }

    public AuditInfo AuditInfo { get; set; }
    
    private ResidentHousehold(Guid id, Resident resident, Household household, AuditInfo auditInfo)
    {
        Id = id;
        ResidentId = resident.Id;
        HouseholdId = household.Id;
        AuditInfo = auditInfo;
    }
    
    public static ResidentHousehold Create(Guid id, 
        Resident resident, 
        Household household)
    {
        var auditInfo = AuditInfo.ProcessCreate();
        var residentHousehold = new ResidentHousehold(id, resident, household, auditInfo);
        return residentHousehold;
    }
}