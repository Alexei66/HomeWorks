namespace SeaBattle.Logic;

public class Result
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }

    // public T? Value { get; set; }

    public static Result Success() => new Result() { IsSuccess = true };

    //public static Result<T> Success(T value) => new Result<T>() { IsSuccess = true, Value = value };

    public static Result Fail(string message) => new Result() { Message = message };
}