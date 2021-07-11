using System;
using System.Collections.Generic;
using System.Linq;

namespace psqlProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            SqlApi api = new SqlApi();
            int id = api.SaveLog(DateTime.Now,"Authentication successful", "INFO", "server");
            Console.WriteLine(id);
            // using (ApplicationContext db = new ApplicationContext())
            // {
            //     Log log1 = new Log { Date = DateTime.Now, Message = "Authentication successful",
            //                          Level = "INFO", Source = "server"};
            //     Log log2 = new Log { Date = DateTime.Now, Message = "Password wrong", 
            //                          Level = "WARNING", Source = "App"};
            //     db.Add(log1);
            //     db.AddRange(log1, log2);
            //     db.SaveChanges();
            //     Console.WriteLine(log1.Id);
            //     Console.WriteLine(log2.Id);
            //     Console.WriteLine("added");
            // }

            // using (ApplicationContext db = new ApplicationContext())
            // {
            //     List<User> users = db.Logs.ToList();
            //     foreach (User item in users)
            //     {
            //         Console.WriteLine($"{item.Id} - {item.Name}, {item.Age} years");
            //     }
            // }
        }
    }
}