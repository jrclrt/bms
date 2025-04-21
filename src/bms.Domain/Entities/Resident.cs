using bms.Domain.Primitives;

namespace bms.Domain.Entities;

public class Resident : Entity
{
    public string FirstName { get; private set; } = null!;
    public string? MiddleName { get; private set; }
    public string LastName { get; private set; } = null!;
    public string? Suffix { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Gender { get; private set; } = null!;
    public string Nationality { get; private set; } = null!;
    public IReadOnlyCollection<ResidentHousehold> ResidentHouseholds => _residentHouseholds;
    private readonly List<ResidentHousehold> _residentHouseholds = new();
    
    private Resident(Guid id, 
        string firstName, 
        string middleName, 
        string lastName, 
        string suffix, 
        DateTime birthDate, 
        string gender, 
        string nationality) : base(id)
    {
        Id = id;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Suffix = suffix;
        BirthDate = birthDate;
        Gender = gender;
        Nationality = nationality;
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
        var resident = new Resident(id, firstName, middleName, lastName, suffix, birthDate, gender, nationality);
        return resident;
    }

    public ResidentHousehold CreateHousehold(Guid householdId)
    {
        var residentHousehold = new ResidentHousehold(Guid.NewGuid(), this.Id, householdId);
        
        _residentHouseholds.Add(residentHousehold);
        
        return residentHousehold;
    }
}