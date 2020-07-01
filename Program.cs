using System;

namespace Лаба1
{
    class Program
    {
        static void Main(string[] args)
        {

            SearchInWidth searchInWidth = new SearchInWidth("J:\\Лабы\\Лаба1\\Лаба1\\MainDir","csv");//Путь к корню, тип файла 

            //Возвращяет список директорий в которых найден файл
            // Изменение файлов
            MyCsvConvert.ConvertCsv(searchInWidth.GetDirs()); 
            
            Console.ReadKey();

        }
    }
}
