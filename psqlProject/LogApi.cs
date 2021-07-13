using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace psqlProject
{
    public class SqlApi
    {
        public string ConnectString;

        public SqlApi(string connectString)
        {
            ConnectString = connectString;
        }

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
                Log log = new Log {Date = date, Message = message, Level = level.ToUpper(), Source = source.ToLower()};
                db.Add(log);
                db.SaveChanges();
                return log.Id;
            }
        }
        
        /// <summary>
        /// Search for events by date range
        /// </summary>
        /// <param name="startDate">The beginning of the countdown</param>
        /// <param name="endDate">The endinging of the countdown</param>
        /// <returns>Found events</returns>
        public List<Log> SearchByDate(DateTime startDate, DateTime endDate)
        {           
            List<Log> logs;
            using (ApplicationContext db = new ApplicationContext())
            {
                logs = db.Logs.Where(log => log.Date >= startDate && log.Date <= endDate).ToList();
            }

            return logs;
        }
        
        /// <summary>
        /// Search for events by message or text in the source name
        /// </summary>
        /// <param name="text">Search text</param>
        /// <returns>Found events</returns>
        public List<Log> SearchByText(string text)
        {
            List<Log> logs;
            using (ApplicationContext db = new ApplicationContext())
            {
                logs = db.Logs.Where(log =>
                    EF.Functions.Like(log.Message, $"%{text.ToLower()}%") || EF.Functions.Like(log.Source, $"%{text}%")).ToList();
            }

            return logs;
        }

        /// <summary>
        /// Search for events by event level
        /// </summary>
        /// <param name="text">Level</param>
        /// <returns>Found events</returns>
        public List<Log> SearchByLevel(string text)
        {
            List<Log> logs;
            using (ApplicationContext db = new ApplicationContext())
            {
                logs = db.Logs.Where(log =>
                    EF.Functions.Like(log.Level, text.ToUpper())).ToList();
            }

            return logs;
        }

        /// <summary>
        /// Remove element the events by Id
        /// </summary>
        /// <param name="idList">List of event ids</param>
        /// <returns>Count of removed events</returns>
        public int RemoveEvent(List<int> idList)
        {
            int count = 0;
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var item in idList)
                {
                    if (db.Logs.Find(item) != null)
                    {
                        db.Logs.Remove(db.Logs.Find(item));
                        count++;
                    }
                }
                db.SaveChanges();
            }
            return count;
        }
        
        /// <summary>
        /// Getting statistics on events
        /// </summary>
        /// <returns>Stat object</returns>
        public Stat GetStat()
        {
            Stat stat = new Stat();
            var levelSet = new HashSet<string>();
            var sourceSet = new HashSet<string>();
            using (ApplicationContext db = new ApplicationContext())
            {
                stat.CountEvents = db.Logs.Count();
                foreach (var item in db.Logs.ToHashSet())
                    levelSet.Add(item.Level);    
                
                foreach (var level in levelSet)
                {
                    var logs = db.Logs.Where(log => log.Level == level);
                    stat.EventsByLevel.Add(level, logs.Count());
                }
                
                foreach (var item in db.Logs.ToHashSet())
                    sourceSet.Add(item.Source);

                foreach (var source in sourceSet)
                {
                    var logs = db.Logs.Where(log => log.Source == source);
                    stat.EventsBySource.Add(source, logs.Count());
                }
            }

            return stat;
        }
    }
}