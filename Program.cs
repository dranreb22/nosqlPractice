using System;
using System.Linq;
using LiteDB;

namespace nosqlPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new LiteDatabase(@"MyData.db")){
                var users = db.GetCollection<User>("users");

                var user = new User{
                    Name = "Bernard Georges",
                    Email = "testemail@hotmail.com"
                };

                users.Insert(user);

                var result = users.Find(x => x.Email == "testemail@hotmail.com").FirstOrDefault();
                Console.WriteLine(result.Name);

                user.Name = "Bernard";
                users.Update(user);

                users.EnsureIndex( x => x.Name);
            }
        }
    }
}
