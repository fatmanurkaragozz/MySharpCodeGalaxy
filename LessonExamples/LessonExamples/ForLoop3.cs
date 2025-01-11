using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class ForLoop3
    {
        static void Main()
        {
            int i = 0, a, n;

            Console.Write("Bir sayı girin : ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Artım miktarı  : ");
            a = Convert.ToInt32(Console.ReadLine());

            for(; i < n;)
            {
                Console.Write(" {0} ", i);
                i += a;
            }

            Console.ReadLine();
        }
    }
}
// Console.Write(" {0} ", i); ifadesindeki " {0} " ifadesi, bir biçimlendirme ifadesidir.
// Süslü parantez içindeki {0}, i değişkeninin değerinin hangi konuma yazdırılacağını gösterir.
// Burada 0, ilk argümanı temsil eder.Yani i değeri, { 0}
// konumuna yazdırılacaktır.
