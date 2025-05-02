using bms.Domain.Results;

namespace bms.Domain.Errors;

public class ResidentErrors
{
    public static readonly Error ResidentNotExists = new("TestCode", "Residdent does not exists!");
}