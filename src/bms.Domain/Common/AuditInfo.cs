namespace bms.Domain.Common;

public class AuditInfo
{
    public bool IsDeleted { get; private set; }
    public string CreatedBy { get; private set; } = null!;
    public string? UpdatedBy { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? UpdatedDate { get; private set; }

    private AuditInfo(bool isDeleted, 
        string createdBy, 
        string? updatedBy, 
        DateTime createdDate, 
        DateTime? updatedDate)
    {
        IsDeleted = isDeleted;
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }
    
    public static AuditInfo ProcessCreate()
    {
        var auditInfo = new AuditInfo(false, "admin", null, DateTime.UtcNow, null);
        return auditInfo;
    }

    public static AuditInfo ProcessUpdate(AuditInfo auditInfo)
    {
        auditInfo.UpdatedBy = "admin";
        auditInfo.UpdatedDate = DateTime.UtcNow;
        
        return auditInfo;
    }
    
    public static AuditInfo ProcessDelete(AuditInfo auditInfo)
    {
        auditInfo.IsDeleted = true;
        return auditInfo;
    }
}