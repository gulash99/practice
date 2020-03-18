using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Hackerrank;

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

                //read data from SampleOutput and from MemoryStream
                try
                {
                    using (StreamReader sr = new StreamReader(SampleOutput))
                    {
                        outputString = sr.ReadToEnd();
                        ms.Position = 0;
                        using (StreamReader sread = new StreamReader(ms))
                        {
                            ourOutputString = sread.ReadToEnd();
                        }
                    }
                    outputString = outputString.Trim(' ', '\r', '\n');
                    ourOutputString= ourOutputString.Trim(' ', '\r', '\n');
                    Console.WriteLine("Our Output String: ");
                    Console.WriteLine(ourOutputString);
                    Console.WriteLine("Output String: ");
                    Console.WriteLine(outputString);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    ourOutputString = "";
                    outputString = "";
                }
                return outputString == ourOutputString;
            }
            else 
            {
                return false;
            }
        }

        
        public static void Main(string[] args)
        {
            string SampleInput = @"GradingStudents\input.txt";
            string SampleOutput = @"GradingStudents\output.txt";
            Console.WriteLine(RunChallenge0(GradingStudentsSolution.Challenge, SampleInput, SampleOutput));
        }
    }
}
