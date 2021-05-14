using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace LINQtoSQL
{
    [Table(Name = "Players")]
    class Players
    {
        [Column(Name="Id",IsPrimaryKey = true, IsDbGenerated = true)]//IsPrimaryKey: хранит логическое значение и указывает, выполняет ли столбец роль первичного ключа (как в данном случае Id)
        public int PlayerId { get; set; }
        [Column]
        public string Name { get; set; }
        [Column(Name = "Position")]//явно прописываем, что берем колонку с именем Name
        public string Position { get; set; }
        [Column]//если же имя колонки совпадает с именем свойства, то можно написать так
        public int Age { get; set; }


    }
}
