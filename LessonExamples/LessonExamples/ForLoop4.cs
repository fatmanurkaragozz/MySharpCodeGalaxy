using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class ForLoop4
    {
        static void Main()
        {
            int sayi;
            Console.Write("Bir tam sayı giriniz : ");
            sayi = Convert.ToInt32(Console.ReadLine());

            // 32 bitlik tam sayının her bir bitini kontrol etmek için döngü
            for(int bit = 32; bit >= 1; bit--)
            {
                // sayi >> (bit - 1) işlemi ile en sağdaki bit değeri alınır ve 1 ile AND işlemine sokulur
                // Bu işlem, sayının ilgili bitinin 0 mı 1 mi olduğunu belirler

                Console.Write("{0}", (sayi >> bit - 1) & 1);
            }
            Console.WriteLine();
        }
    }
}
