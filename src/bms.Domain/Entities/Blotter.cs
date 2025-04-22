using bms.Domain.Common;

namespace bms.Domain.Entities;

public class Blotter
{
    private readonly List<Resident> _respondents = new();
    private readonly List<Resident> _witnesses = new();
    
    public Guid Id { get; private set; }
    public Resident Complainant { get; private set; } = null!;
    public IReadOnlyCollection<Resident> Respondents => _respondents;
    public IReadOnlyCollection<Resident> Witnesses => _witnesses;
    public string Location { get; private set; } = null!;
    public string Narrative { get; private set; } = null!;
    public DateTime IncidentDateTime { get; set; }
    public AuditInfo AuditInfo { get; private set; }

    private Blotter(Guid id,
        Resident complainant,
        List<Resident> respondents,
        List<Resident> witnesses,
        string location,
        string narrative,
        DateTime incidentDateTime,
        AuditInfo auditInfo)
    {
        Id = id;
        Complainant = complainant;
        _respondents = respondents;
        _witnesses = witnesses;
        Location = location;
        Narrative = narrative;
        IncidentDateTime = incidentDateTime;
        AuditInfo = auditInfo;
    }
    
    public static Blotter Create(Guid id,
        Resident complainant,
        List<Resident> respondents,
        List<Resident> witnesses,
        string location,
        string narrative,
        DateTime incidentDateTime)
    {
        var auditInfo = AuditInfo.ProcessCreate();
        var blotter = new Blotter(id, 
            complainant, 
            respondents, 
            witnesses, 
            location, 
            narrative, 
            incidentDateTime, 
            auditInfo);
        
        return blotter;
    }
}