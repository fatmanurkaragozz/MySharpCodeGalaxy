using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class Metot2
    {
        static void OrnekMetot(double x, double y)
        {
            Console.WriteLine("1.Metot");
        }
        static void OrnekMetot(byte x, byte y) // 0-255 arası değerler alır
        {
            Console.WriteLine("2.Metot");
        }
        static void Main()
        {
            OrnekMetot(1919, 1923);
            OrnekMetot(12, 34);
            Console.ReadLine();
        }
    }
}
