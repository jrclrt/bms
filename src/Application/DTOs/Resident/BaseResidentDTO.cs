namespace Application.DTOs.Resident;

public class BaseResidentDTO
{
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = null!;
    public string? Suffix { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public string Nationality { get; set; } = null!;
}
