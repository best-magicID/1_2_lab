using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Лаба1
{
    class SearchInWidth
    {
        string TypeFiles { get; set; }
        string MainDir { get; set; }
        List<string> ListTestedDir = new List<string>();
        List<string> ListDir;

        public SearchInWidth(string MainDir, string TypeFiles)
        {
            this.TypeFiles = TypeFiles;
            this.MainDir = MainDir;
            ListTestedDir.Add(MainDir);
            ListDir = Directory.EnumerateDirectories(MainDir).ToList();
            ListDir.ForEach(item => ListTestedDir.Add(item));
            Func(ListDir);
        }

        //Метод несовсем реккурсивный
        void Func(List<string> list)
        {
            if (list.LongCount() != 0)
            {
                List<string> listCopy = new List<string>();
                foreach (var n in list)
                {
                    Directory.EnumerateDirectories(n).ToList().ForEach(item => listCopy.Add(item));
                }

                listCopy.ForEach(item => ListTestedDir.Add(item));
                Func(listCopy);
            }
            else
            {
                Console.WriteLine("Достигнуто дно!");
            }
        }

        public List<string[]> GetDirs()
        {
            return ListTestedDir.Select(item => Directory.GetFiles(item)).
                   ToArray().Where(item => item.LongLength != 0).
                   Where(item => item[0].Contains(TypeFiles)).ToList();
        }

    }
}
