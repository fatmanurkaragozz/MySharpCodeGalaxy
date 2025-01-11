using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class CopyToCopy
    {
        static void Main()
        {
            int[] dizi1 = { 1, 2, 3, 4, 5, 6, 7 };
            int[] dizi2 = new int[10];
            int[] dizi3 = new int[10];

            dizi1.CopyTo(dizi2, 2); // dizi2'ye dizi1'in elemanları dizi2'nin 2. elemanından 
                                    // sonra kopyalanıyor

            foreach (int i in dizi2) // Bu kısımda dizi2'nin elemanlarının konsolda yazdırılma 
                                     // işlemi gerçekleştiriliyor.
            {
                Console.Write(i);
            }

            Console.WriteLine();

            Array.Copy(dizi1, 2, dizi3, 5, 3); // dizi1'in 2. elemanından sonraki ilk 3 elemanı
                                               // dizi3'ün 5. elemanından sonraya yazdırılıyor.

            foreach(int i in dizi3) // Bu kısımda dizi3'ün elemanlarının konsolda yazdırılma 
                                    // işlemi gerçekleştiriliyor.
            {
                Console.Write(i);
            }

            Console.ReadLine();
        }
    }
}
