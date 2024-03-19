﻿
namespace publishers.Infrastructure.Exceptions
{
    public class JobsException : Exception
    {
        public JobsException(string message) : base(message) 
        {
            SaveLog(message);
        }

        public void SaveLog(string message)
        {

        }

    }
}