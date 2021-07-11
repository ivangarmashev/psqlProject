using System;

namespace psqlProject
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Date  { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public string Source { get; set; }

        // public Log(DateTime date, string message, string level, string source)
        // {
        //     Date = date;
        //     Message = message;
        //     Level = level;
        //     Source = source;
        // }
    }
}