using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class Method3
    {
        static void DiziYaz(int[] a, int Sekil)
        {
            if(Sekil == 0)
            {
                foreach (Object o in a)
                {
                    Console.Write(o.ToString() + " ");
                }
                Console.WriteLine();
            }
            else if (Sekil == 1)
            {
                int x = 1; // Eleman sayısı
                foreach(Object o in a)
                {
                    Console.Write("{0,5}", o.ToString()); // Elemanı yazdır
                    if (x % 3 == 0) // Her 3 elemanda bir satır başı yap
                    {
                        Console.WriteLine();
                    }
                    x++; // Her iterasyonda sırayı artır
                }
            }
            else
            {
                foreach(Object o in a)
                {
                    Console.WriteLine(o.ToString());
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            int[] dizi = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            DiziYaz(dizi, 0); // Yan yana yazdır
            DiziYaz(dizi, 1); // 3'erli yazdır
            DiziYaz(dizi, 2); // Alt alta yazdır

            Console.ReadLine();
        }
    }
}
