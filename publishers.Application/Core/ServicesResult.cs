
namespace publishers.Application.Core
{
    public class ServicesResult<TData>
    {
        public ServicesResult()
        {
            this.Success = true;
        }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public TData? Data { get; set; }
    }
}
