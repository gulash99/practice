using System;
using System.IO;


namespace Hackerrank
{
    static class GradingStudentsSolution
    {
        static int[] gradingStudents(int[] grades)
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
        public static void Challenge(StreamReader streamReader, StreamWriter streamWriter)
        {
            int n = Convert.ToInt32(streamReader.ReadLine());
            int[] grades = new int[n];
            for (int i = 0; i < n; i++)
                grades[i] = Convert.ToInt32(streamReader.ReadLine());
            int[] result = gradingStudents(grades);
            streamWriter.WriteLine(String.Join("\n", result));
            streamWriter.Flush();

        }
    }
}

