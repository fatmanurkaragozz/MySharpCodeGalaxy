using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class OperatorOverloading2
    {

        public int x, y;
        public OperatorOverloading2 (int dd, int ff)
        {
            x = dd; y = ff;
        }

        public void yaz()
        {
            Console.WriteLine(x + " " + y);
        }

        public static OperatorOverloading2 operator +(OperatorOverloading2 a, OperatorOverloading2 b)
        {
            int c = a.x + a.y; int z = b.x + b.y;
            return new OperatorOverloading2(c, z);
        }

    }

    class Sinif
    {
        static void Main()
        {
            OperatorOverloading2 a = new OperatorOverloading2(5, 8);
            OperatorOverloading2 b = new OperatorOverloading2(7, 9);
            OperatorOverloading2 m = new OperatorOverloading2(6, 2);

            OperatorOverloading2 c = a + b + m;  c.yaz();
            Console.ReadLine();
        }
    }
}
