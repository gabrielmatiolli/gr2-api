namespace gr2_api.Objects;

public class Result<T>
{
  public bool IsSuccess { get; }
  public string Error { get; }
  public T Value { get; }

  protected Result(bool isSuccess, T value, string error)
  {
    IsSuccess = isSuccess;
    Error = error;
    Value = value;
  }

  public static Result<T> Ok(T value) => new Result<T>(true, value, null);
  public static Result<T> Fail(string error) => new Result<T>(false, default(T), error);
}