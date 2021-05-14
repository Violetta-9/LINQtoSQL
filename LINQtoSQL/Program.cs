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
            var plauersSwap=players.Where()
            foreach (var item in plauersswap)
            {
                Console.WriteLine("{0} \t{1} \t{2} \t{3}",item.PlayerId, item.Name,item.Position, item.Age);
            }

        }
    }
}
