using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class Metot1
    {
        public static void metotlar(int a, int b = 2, int c = 4)
        {
            Console.WriteLine(" a= " + a + " b= " + b + " c=" + c);
        }
        static void Main(string[] args)
        {
            metotlar(1); metotlar(5, 8); metotlar(3, 6, 9);

            Console.ReadLine();
        }

    }
}
