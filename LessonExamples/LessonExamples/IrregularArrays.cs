using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class IrregularArrays
    {
        static void Main()
        {

            int[][] dizi = new int[3][];

            dizi[0] = new int[] { 1, 2 };          // 1. alt dizi: 2 elemanlı
            dizi[1] = new int[] { 3, 4, 5, 6, 7 }; // 2. alt dizi: 5 elemanlı
            dizi[2] = new int[] { 8, 9, 0 };       // 3. alt dizi: 3 elemanlı 

            foreach (int[] boyut in dizi) // Ana dizideki her alt diziye sırayla erişilir
            {
                foreach (int eleman in boyut) // Alt dizideki her eleman işlenir
                {
                    Console.Write("{0,3}", eleman); // Eleman 3 karakterlik boşlukla yazdırılır
                }
                Console.WriteLine(); // Eleman 3 karakterlik boşlukla yazdırılır
            }

            Console.ReadLine(); // Alt dizi tamamlandığında alt satıra geçilir
        }
    }
}
