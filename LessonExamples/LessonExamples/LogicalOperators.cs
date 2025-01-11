using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class LogicalOperators
    {
        public static void Main()
        {

            int a = 10;
            int b = 2;
            int c = -10;

            Console.WriteLine("bit ve işlemi = " + (int)(a & b));
            Console.WriteLine("bit veya işlemi = " + (int)(a | b));
            Console.WriteLine("bit tümleyen işlemi = " + (int)(~a));
            Console.WriteLine("bit tümleyen işlemi = " + ~c); //(int) cast yapılmasada olur.
            Console.WriteLine("bit sola kaydırma = " + (int)(1 << b));
            Console.WriteLine("bit sağa kaydırma = " + (1 >> b));
            Console.WriteLine("bit xor işlemi = " + (int)(1 ^ b));
            Console.WriteLine("bit tümleyen işlemi = " + (byte)(~a)); // ikiliğe dönüştürdü

            Console.WriteLine("--------------------------------");

            int x = 2;
            int y = 3;
            int z = 6;

            Console.WriteLine(" (x & y) --> " + (x & y));
            Console.WriteLine(" (x | y) --> " + (x | y));
            Console.WriteLine(" (x ^ y) --> " + (x ^ y));
            Console.WriteLine(" ( ~x ) --> " + (~x));
            Console.WriteLine(" ( ~y ) --> " + (~y));
            Console.WriteLine(" ( ~z ) --> " + (~z));
            Console.ReadLine();
        }
    }
}

// Tümleyen işleminde sayı 256'dan çıkarılır.
// xor işleminde bit değerleri aynı ise 0 farklı ise 1 değerini döndürür.