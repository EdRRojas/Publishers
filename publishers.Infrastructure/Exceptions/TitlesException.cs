

namespace publishers.Domain.Exceptions
{
    public class TitlesException : Exception
    {
        public TitlesException(string message) : base(message)
        {
            SaveLog(message);
        }
        public void SaveLog(string message)
        {

        }
    }
}
