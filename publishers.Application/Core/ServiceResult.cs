//En esta clase tendre todos los posibles resultados que puede arrojar mi API

namespace publishers.Application.Core
{
    public class ServiceResult<TData>
    {
        public ServiceResult()
        {
            Success = true;
        }
        public string? Message { get; set; }
        public bool? Success { get; set; }
        public TData Data { get; set; }
    }
}
