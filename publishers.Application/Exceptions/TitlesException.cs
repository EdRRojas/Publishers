using Microsoft.Extensions.Logging;
using publishers.Application.Service;

namespace publishers.Application.Exceptions
{
    public class TitlesException : Exception
    {
        private ILogger<TitlesServices> Logger { get; set; }
        public TitlesException(string message, Exception exception, ILogger<TitlesServices> logger)
            : base(message, exception)
        {
            Logger = logger;
        }    
               
        
        public void TitleLogError(string message, Exception exception)
        {
            Logger.LogError(message, exception.ToString());            
        }
        
    }
    
}
