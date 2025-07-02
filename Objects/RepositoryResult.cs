namespace gr2_api.Objects;

public class RepositoryResult<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string Error { get; set; }

    public static RepositoryResult<T> Ok(T data) =>
        new RepositoryResult<T> { Success = true, Data = data };

    public static RepositoryResult<T> Fail(string error) =>
        new RepositoryResult<T> { Success = false, Error = error };
}