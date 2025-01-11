using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class RecursiveMethod
    {

        static int Faktoriyel(int a)
        {
            if (a == 0) // Temel durum (base case)
            {
                return 1;
            }

            return a * Faktoriyel(a - 1); // fonksiyon kendi içerisinde çağrıldı
                                          // Özyineleme (recursive çağrı)
        }

        static void Main()
        {
            Console.Write("Faktöriyelini alacağınız sayıyı giriniz :");

            int fak_degeri = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Girmiş olduğunuz sayının faktöriyeli : " + Faktoriyel(fak_degeri));
            Console.ReadLine();
        }
    }
}

// Kullanıcı 3 girer.
// Faktoriyel(3) çağrılır:
// 3 * Faktoriyel(2)
// 3 * (2 * Faktoriyel(1))
// 3 * (2 * ( 1 * Faktoriyel(0)))
// 3 * (2 * ( 1 ))
