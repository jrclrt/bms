namespace Domain.Entities;

public class BaseModel
{
    // Key
    public int Id { get; set; }

    // Row attribute
    public bool IsDeleted { get; set; }

    // Audit Fields
    public string CreatedBy { get; set; } = null!;
    public string? UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}