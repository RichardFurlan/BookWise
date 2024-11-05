namespace BookWise.Application.DTOs;

public record ResultViewModel(bool IsSuccess = true, string Message = "")
{
    public static ResultViewModel Success()
        => new();

    public static ResultViewModel Error(string message)
        => new(false, message);
};

public record ResultViewModel<T>(T? Data = default, bool IsSuccess = true, string Message = "")
    : ResultViewModel(IsSuccess, Message)
{
    public static ResultViewModel<T> Success(T data)
        => new(data);

    public static ResultViewModel<T> Error(string message)
        => new(default, false, message);
}