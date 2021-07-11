using System;
using System.Collections.Generic;
using System.Linq;

namespace psqlProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User {Name = "Ivan", Age = 21};
                User user2 = new User {Name = "Alex", Age = 21};
                
                db.AddRange(user1, user2);
                db.SaveChanges();
                Console.WriteLine("added");
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> users = db.Users.ToList();
                foreach (User item in users)
                {
                    Console.WriteLine($"{item.Id} - {item.Name}, {item.Age} years");
                }
            }
        }
    }
}