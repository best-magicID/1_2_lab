using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба1
{
    class MyCsvConvert
    {
        public static void ConvertCsv(List<string[]> ListPath)
        {
            foreach (var n in ListPath)
            {
                string textFromFile;
                using (FileStream fileStream = File.OpenRead(n[0]))
                {
                    byte[] array = new byte[fileStream.Length];
                    fileStream.Read(array, 0, array.Length);
                    textFromFile = Encoding.Default.GetString(array);
                }

                var text = textFromFile.Split('\n', ';');

                var head = text.Take(2).ToArray();
                var data = text.Skip(2).ToArray();

                for (int i = 1; i < data.LongCount(); i += 2)
                {
                    data[i - 1] = data[i - 1] + ";";
                    int x = 0;
                    data[i] = data[i].Take(4).
                        Select(item => Convert.ToInt32(item) - 48).
                        Aggregate(0, (sum, item) => sum + item * (int)Math.Pow(2, x++)).ToString() + "\n";
                }

                string inputstr = head[0] + ";" + head[1] + "\n";
                data.ToList().ForEach(item => inputstr += item);

                using (StreamWriter textcsv = new StreamWriter(n[0], false, Encoding.Default))
                {
                    textcsv.WriteLine(inputstr);
                }
            }

            Console.Write("Files changed !");
        }
    }
}
