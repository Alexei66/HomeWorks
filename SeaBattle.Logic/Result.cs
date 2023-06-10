namespace SeaBattle.Logic;

public class Result
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }

    public static Result Success() => new Result() { IsSuccess = true };

    public static Result Fail(string message) => new Result() { Message = message };
}