
namespace publishers.Infrastructure.Exceptions
{
    public  class RoyschedExection : Exception
    {
        public RoyschedExection(string message) : base(message) 
        {
            SaveLog(message);
        }

        public void SaveLog(string message)
        {

        }
    }
}
