using System;
using System.IO;
using System.Linq;

namespace Loader
{
    class Program
    {
        // public static bool RunChellenge(Action<StreamReader, StreamWriter> challenge, string inputPath, string outputPath)
        public static bool RunChellenge(int c, int d)
        {
            ////////////////////проверка существования
            string path = @"C:\Users\Даша\source\repos\tmp.txt";
            if (Directory.Exists(path))
            {
                Console.WriteLine("File is not found");
            }

            ///////////////////считаем весь текст из полностью записанного ранее файла
            Console.WriteLine("Output:  ");
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ////////////////////вывод строки или числа в пустой файл
            Console.WriteLine("Program exit:  ");
            string writePath = @"C:\Users\Даша\source\repos\tmp2.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    //sw.WriteLine("Дозапись");
                    string C = Convert.ToString(c);
                    string D = Convert.ToString(d);
                    sw.Write(C);
                    sw.Write(D);
                }
                using (StreamReader sr = new StreamReader(writePath))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //////////////////cравнение двух файлов сначала по длине, потом по байтам
            if (new FileInfo(path).Length != new FileInfo(writePath).Length)
            {
                return false;
            }
            else
            {
                return (File.ReadAllBytes(path).SequenceEqual(File.ReadAllBytes(writePath)));
            }
        }


        static void Main(string[] args)
        {
            //if (result==RunChellenge(Action < StreamReader, StreamWriter > challenge, inputPath, outputPath))

            Console.WriteLine(RunChellenge(2, 3));
        }
    }
}
