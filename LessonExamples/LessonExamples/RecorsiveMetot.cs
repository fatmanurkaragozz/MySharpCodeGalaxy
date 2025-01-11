using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class RecursiveMetot
    {
        static void BitYaz(int b)
        {
            if (b == 0) return; // b = 0 ise metodu sonlandır
            BitYaz(b >> 1);     // Sayıyı sağa doğru bir bit kaydır (b/2 işlemi gibi)
            Console.Write(b & 1); // Console.Write(b); ikiye bölümden kalan sonucu yazar
        }                         // & = ve
        static void Main()
        {
            BitYaz(15); Console.WriteLine(); // 1 3 5 7 15
            BitYaz(32); Console.WriteLine(); // 1 2 4 8 16 32
            Console.ReadLine();
        }
    }
}
