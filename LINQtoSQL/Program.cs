using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace LINQtoSQL
{
    class Program
    {
        static string connectionString = @"Data Source=DESKTOP-NVEEOK3\SQLEXPRESS;Initial Catalog=Football;Integrated Security=True";
        static void Main(string[] args)
        {
            DataContext db = new DataContext(connectionString);//Сначала создается контекст данных, который представлен объектом DataContext.В конструктор этого класса передается строка подключения.Через контекст данных мы будем работать с базой данных.

           // Получаем таблицу пользователей
           Table<Players> players = db.GetTable<Players>();
            var plauersswap = from item in players
                              where item.Age > 18
                              orderby item.Name
                              select item;

            var plauersSwap = players.Where(item => item.Age >= 18).OrderBy(item => item.Age).ThenBy(item => item.PlayerId);
            foreach (var item in plauersSwap)
            {
                Console.WriteLine("{0} \t{1} \t{2} \t{3}", item.PlayerId, item.Name, item.Position, item.Age);
            }
           
            var playerGroyps = players.GroupBy(item => item.Age);
            foreach (var item in playerGroyps)
            {
                Console.WriteLine($"Key{item.Key}");
                foreach (var items in item)
                {
                    Console.WriteLine(items.Name);

                }

            }
            var db1 = new DataContext(connectionString);
            var count = db1.GetTable<Players>().Count();
            if (count>0)
            {

                var query = db1.GetTable<Players>().Skip(1).Take(2);

                foreach (var item in query)
                {
                    Console.WriteLine("{0} \t{1} \t{2}", item.PlayerId, item.Name, item.Age);
                }
            }

            var players1=players.FirstOrDefault();
            players1.Name = "Алеся";
            db.SubmitChanges();

            Console.WriteLine();

            foreach (var item in players)
            {
                Console.WriteLine("{0} \t{1} \t{2}", item.PlayerId, item.Name, item.Age);
            }
            //var playerNew = new Players { Name = "Антон", Age = 25, Position = "Нападающий" };
            //players.InsertOnSubmit(playerNew);
            //db.SubmitChanges();
            //Console.WriteLine();
            //foreach (var item in players)
            //{
            //    Console.WriteLine("{0} \t{1} \t{2}", item.PlayerId, item.Name, item.Age);
            //}
            //Console.WriteLine();
            //var playerList = new List<Players>()
            //{
            //    new Players{ Name="Vasj",Age=34,Position="Нападающий"},
            //    new Players{ Name="Таня",Age=34,Position="Вротарь"},
            //    new Players{ Name="Маша",Age=34,Position="Главный"}

            //};
            //players.InsertAllOnSubmit(playerList);
            //db.SubmitChanges();
            //foreach (var item in players)
            //{
            //    Console.WriteLine("{0} \t{1} \t{2}", item.PlayerId, item.Name, item.Age);
            //}
            var playerDelete = players.FirstOrDefault(item=>item.Name=="Антон ");
            try
            {
                players.DeleteOnSubmit(playerDelete);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }
            db.SubmitChanges();
            Console.WriteLine();
            foreach (var item in players)
            {
                Console.WriteLine("{0} \t{1} \t{2}", item.PlayerId, item.Name, item.Age);
            }
            Console.WriteLine();
            Console.WriteLine();

            //players.DeleteAllOnSubmit(players);
            //db.SubmitChanges();
            //Console.WriteLine("Вывод");
            //foreach (var item in players)
            //{
            //    Console.WriteLine("{0} \t{1} \t{2}", item.PlayerId, item.Name, item.Age);
            //}

        }
    }
}
