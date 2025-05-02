namespace bms.Domain.Results;

public class Result<T>
{
    private readonly T? _value;
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public T Value
    {
        get
        {
            if (IsFailure)
                throw new InvalidOperationException();
            
            return _value!;
        }
        
        private init => _value = value;
    }

    public Error Error { get; }
    
    private Result(T value)
    {
        Value = value;
        IsSuccess = true;
        Error = Error.None;
    }
    
    private Result(Error error)
    {
        if (error == Error.None)
            throw new ArgumentException();
        
        IsSuccess = true;
        Error = Error;
    }
    
    public static Result<T> Success(T value) => new Result<T>(value);
    public static Result<T> Failure(Error error) => new Result<T>(error);
}