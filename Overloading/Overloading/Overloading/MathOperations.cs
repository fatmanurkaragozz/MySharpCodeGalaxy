using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading.Overloading
{
    class MathOperations
    {
        // İlk sürüm: İki tam sayıyı toplar
        public int Topla(int a, int b)
        {
            return a + b;
        }

        // İkinci sürüm: Üç tam sayıyı toplar
        public int Topla(int a, int b, int c)
        {
            return a + b + c;
        }

        // Üçüncü sürüm: Bir dizi (array) tam sayıyı toplar
        public int Topla(int[] sayilar)
        {
            int toplam = 0;
            foreach (int sayi in sayilar)
            {
                toplam += sayi;  // Dizi elemanlarını toplar
            }
            return toplam;
        }
    }

    class Program2
    {
        static void Main()
        {
            MathOperations mathOps = new MathOperations();

            // İlk sürüm: İki tam sayı toplama
            int sonuc1 = mathOps.Topla(3, 5);
            Console.WriteLine("İki sayının toplamı: " + sonuc1);  // Çıktı: 8

            // İkinci sürüm: Üç tam sayı toplama
            int sonuc2 = mathOps.Topla(1, 2, 3);
            Console.WriteLine("Üç sayının toplamı: " + sonuc2);  // Çıktı: 6

            // Üçüncü sürüm: Bir dizi tam sayı toplama
            int[] sayilar = { 1, 2, 3, 4, 5 };
            int sonuc3 = mathOps.Topla(sayilar);
            Console.WriteLine("Dizideki sayıların toplamı: " + sonuc3);  // Çıktı: 15
            Console.ReadLine();
        }
    }
}
