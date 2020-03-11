using System;
using System.IO;
using System.Linq;

namespace Loader
{
    class Program
    {
        // public static bool RunChallenge(Action<StreamReader, StreamWriter> challenge, string inputPath, string outputPath)
        public static bool RunChallenge(int c, int d)
        {
            //check for file existence
            string path = @"C:\Users\Даша\source\repos\tmp.txt";
            if (File.Exists(path))
            {
                string text1 ="";
                string text2 ="";
                //we consider the solution of the problem from the file
                Console.WriteLine("Output:  ");
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        Console.WriteLine(sr.ReadToEnd());
                    }
                    using (StreamReader sr = new StreamReader(path))
                    {
                        text1 = sr.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //entering our data into a file
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
                    using (StreamReader sr = new StreamReader(writePath))
                    {
                        text2=sr.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //compare of two lines
                if (text1 == text2) {
                    return true;
                }
                else
                {
                    return false;
                }
                /*
                //cравнение двух файлов сначала по длине, потом по байтам
                if (new FileInfo(path).Length != new FileInfo(writePath).Length)
                {
                    return false;
                }
                else
                {
                    return (File.ReadAllBytes(path).SequenceEqual(File.ReadAllBytes(writePath)));
                }
                */
            }
            else 
            { 
                return false;
            }
            
        }


        static void Main(string[] args)
        {
            //if (result==RunChellenge(Action < StreamReader, StreamWriter > challenge, inputPath, outputPath))
            Console.WriteLine(RunChallenge(2, 3));
        }
    }
}
