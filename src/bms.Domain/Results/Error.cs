namespace bms.Domain.Results;

public sealed record Error(string Code, string Message)
{
    private static readonly string _recordNotFoundCode = "RecordNotFound";
    private static readonly string _validationErrorCode = "ValidationError";
    
    public static readonly Error None = new(string.Empty, string.Empty);
    
    public static Error RecordNotFound(string message) => new Error(_recordNotFoundCode, message);
    public static Error ValidationError(string message) => new Error(_validationErrorCode, message);
    //public static implicit operator Result(Error error) => Result.Failure(error);
}