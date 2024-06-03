using System.Text.Json.Serialization;

namespace Example.Shared.BaseDTOs;

public class BaseResult<T>
{
    public T Data { get; set; }

    [JsonIgnore] public int StatusCode { get; set; }

    [JsonIgnore] public bool IsSuccessful { get; set; }

    public List<string> Errors { get; set; }

    public static BaseResult<T> Success(T data, int statusCode)
    {
        return new BaseResult<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
    }

    public static BaseResult<T> Success(int statusCode)
    {
        return new BaseResult<T> { Data = default(T), StatusCode = statusCode, IsSuccessful = true };
    }

    public static BaseResult<T> Fail(List<string> errors, int statusCode)

    {
        return new BaseResult<T>
        {
            Errors = errors,
            StatusCode = statusCode,
            IsSuccessful = false
        };
    }

    public static BaseResult<T> Fail(string error, int statusCode)
    {
        return new BaseResult<T>
            { Errors = new List<string>() { error }, StatusCode = statusCode, IsSuccessful = false };
    }
}