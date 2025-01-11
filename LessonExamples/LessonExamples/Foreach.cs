using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class Foreach
    {
        static void Main()
        {
            string[] isimler = { "ali", "ahmet", "selda", "canan" };

            Console.WriteLine("aranan isin= ");
            string aranan = Console.ReadLine();

            bool bulundu = false; // ismin bulunup bulunmdığını takip etmek için

            // foreach döngüsündeki ss, döngü sırasında dizideki her bir öğeyi temsil 
            // eden geçici bir değişkendir.

            foreach(string ss in isimler)
            {
                if (aranan.Equals(ss, StringComparison.OrdinalIgnoreCase)) // Büyük/küçük harf duyarsız karşılaştırma
                {
                    Console.WriteLine("aranan isim bulundu !");
                    bulundu = true;
                    break;
                }
            }

            if (!bulundu)
            {
                Console.WriteLine("İsim yok!");
            }
            Console.ReadKey();
        }
    }
}
// Comparison : karşılaştırma
// ordinal ignore case : sıralı görmezden gelme durumu