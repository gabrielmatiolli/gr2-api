namespace gr2_api.Objects;

public class ServiceResult<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string Error { get; set; }

    public static ServiceResult<T> Ok(T data) =>
        new ServiceResult<T> { Success = true, Data = data };

    public static ServiceResult<T> Fail(string error) =>
        new ServiceResult<T> { Success = false, Error = error };
}