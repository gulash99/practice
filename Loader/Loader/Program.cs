using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Loader
{
    class Program
    {
        public static bool RunChallenge0(Action<StreamReader, StreamWriter> challenge, string SampleInput, string SampleOutput)
        {
            //check for file existence
            if (File.Exists(SampleInput)&& File.Exists(SampleOutput))
            {
                MemoryStream ms = new MemoryStream();
                StreamWriter sw = new StreamWriter(ms);
                string inputString, outputString, ourOutputString;

                //read data from SampleInput
                try
                {
                    using (StreamReader sr = new StreamReader(SampleInput))
                    {
                        inputString = sr.ReadToEnd();
                        sr.BaseStream.Position = 0;
                        challenge(sr, sw);
                    }
                    Console.WriteLine("Input String: ");
                    Console.WriteLine(inputString); ;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    inputString = "";
                }

                //read data from SampleOutput
                try
                {
                    using (StreamReader sr = new StreamReader(SampleOutput))
                    {
                        outputString = sr.ReadToEnd();
                        Console.WriteLine("Output String: ");
                        Console.WriteLine(outputString);
                        sr.BaseStream.Position = 0;
                        ms.Position = 0;
                        using (StreamReader srr = new StreamReader(ms))
                        {
                            ourOutputString = srr.ReadToEnd();
                            Console.WriteLine("Our Output String: ");
                            Console.WriteLine(ourOutputString);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    ourOutputString = "";
                    outputString = "";
                }
                return (outputString == ourOutputString);
            }
            else 
            {
                return false;
            }
        }

        public static int[] gradingStudents(int[] grades)
        {
            for (int i = 0; i < grades.Length; i++)
            {
                var item = grades[i];
                if (item >= 38)
                {
                    var diff = 5 - (item % 5);
                    if (diff < 3)
                        grades[i] = item + diff;
                }
            }
            return grades;
        }
        public static void challenge(StreamReader streamReader, StreamWriter streamWriter)
        {
            TextWriter textWriter = streamWriter;
            int gradesCount = Convert.ToInt32(streamReader.ReadLine());
            int[] grades = new int[gradesCount];
            for (int i = 0; i < gradesCount; i++)
            {
                grades[i] = Convert.ToInt32(streamReader.ReadLine());
            }
            int[] result = gradingStudents(grades);
            textWriter.WriteLine(String.Join("\n", result));
            textWriter.Flush();    
        }
        public static void Main(string[] args)
        {
            string SampleInput = @"C:\Users\Даша\source\repos\tmp.txt";
            string SampleOutput = @"C:\Users\Даша\source\repos\tmp2.txt";
            Console.WriteLine(RunChallenge0(challenge, SampleInput, SampleOutput));
        }
    }
}
