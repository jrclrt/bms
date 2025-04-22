using bms.Domain.Aggregates.Residenthouseholds;
using bms.Domain.Common;

namespace bms.Domain.Entities;

public class Resident
{
    private readonly List<ResidentHousehold> _residentHouseholds = new();
    
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string? MiddleName { get; private set; }
    public string LastName { get; private set; } = null!;
    public string? Suffix { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Gender { get; private set; } = null!;
    public string Nationality { get; private set; } = null!;
    public AuditInfo AuditInfo { get; private set; }
    public IReadOnlyCollection<ResidentHousehold> ResidentHouseholds => _residentHouseholds;
    
    
    private Resident(Guid id, 
        string firstName, 
        string middleName, 
        string lastName, 
        string suffix, 
        DateTime birthDate, 
        string gender, 
        string nationality,
        AuditInfo auditInfo)
    {
        Id = id;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Suffix = suffix;
        BirthDate = birthDate;
        Gender = gender;
        Nationality = nationality;
        AuditInfo = auditInfo;
    }

    public static Resident Create(Guid id, 
        string firstName, 
        string middleName, 
        string lastName, 
        string suffix, 
        DateTime birthDate, 
        string gender, 
        string nationality)
    {
        var auditInfo = AuditInfo.ProcessCreate();
        var resident = new Resident(id,
            firstName, 
            middleName, 
            lastName, 
            suffix, 
            birthDate, 
            gender, 
            nationality, 
            auditInfo);
        
        return resident;
    }

    public ResidentHousehold CreateHousehold(Household household)
    {
        var residentHousehold = ResidentHousehold.Create(Guid.NewGuid(), this, household);
        
        _residentHouseholds.Add(residentHousehold);
        
        return residentHousehold;
    }
}