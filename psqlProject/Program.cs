using System;
using System.Collections.Generic;

namespace psqlProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string connect = "host=localhost;port=5432;database=DbNew;username=postgres;password=0550";
            List<Log> logsByDate;
            List<Log> logsByText;
            List<Log> logsByLevel;
            int countRemove;
            Stat stat;
            
            SqlApi api = new SqlApi(connect);

            int id = api.SaveLog(DateTime.Now, "Authentication successful", "INFO", "server");
            api.SaveLog(new DateTime(2020, 12, 12, 12, 12, 12), "Exception", "ERROR", "server");
            api.SaveLog(new DateTime(2022, 12, 12, 12, 12, 12), "Session closed", "INFO", "app");

            logsByDate = api.SearchByDate(new DateTime(2020, 12, 12, 12, 12, 1),
                new DateTime(2021, 12, 12, 12, 12, 1));
            logsByText = api.SearchByText("aUth");
            logsByLevel = api.SearchByLevel("Info");

            countRemove = api.RemoveEvent(new List<int>(){1});

            stat = api.GetStat();
        }
    }
}