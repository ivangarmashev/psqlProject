using System;

namespace psqlProject
{
    public class SqlApi
    {
        /// <summary>
        /// Adding an event to the log
        /// </summary>
        /// <param name="date">The date of the event</param>
        /// <param name="message">The message of the event</param>
        /// <param name="level">The level of the event</param>
        /// <param name="source">Name of the event source</param>
        /// <returns>The unique id (primary key) of the added event</returns>
        public int SaveLog(DateTime date, string message, string level, string source)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Log log = new Log {Date = date, Message = message, Level = level, Source = source};
                db.Add(log);
                db.SaveChanges();
                return log.Id;
            }
        }
    }
}