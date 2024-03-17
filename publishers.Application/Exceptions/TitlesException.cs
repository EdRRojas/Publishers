using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace publishers.Application.Exceptions
{
    public class TitlesException : Exception
    {
        private ILogger<TitlesException> Logger { get; set; }
        private Exception exception;
        public TitlesException(ILogger<TitlesException> Logger, Exception exception)
        {
            this.Logger = Logger;
            this.exception = exception;
            
        }          
        
        public void TitleLogError(string message, Exception exception)
        {
            Logger.LogError(message, exception.ToString());
            
        }
        
    }
    
}
