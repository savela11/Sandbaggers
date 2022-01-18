
namespace API.Utility;

public class ServiceResponse<T> 
{
    public T? Data { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string? Message { get; set; }
    
    public IEnumerable<string>? Errors { get; set; } =  new List<string>();
}
