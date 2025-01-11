using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class Arrays
    {
        public static void Main()
        {
            // 4x4 boyutunda bir iki boyutlu dizi (matris) tanımlanıyor
            int[,] dizi = new int[4, 4];
            int k = 1; // Dizi elemanlarını doldurmak için kullanılacak sayaç

            // Çok boyutlu diziyi doldurmak için iç içe for döngüleri
            for (int i = 0; i < 4; i++) // Dizi satırlarını dolaşır
            {
                for (int j = i; j < 4; j++) // Üst üçgen kısmını doldurur
                {
                    dizi[i, j] = k; // Üst üçgen elemanına değer atama
                    dizi[j, i] = k; // Simetrik elemanına aynı değeri atama
                    k++; // Her atamadan sonra sayacı bir artır
                }
            }

            // Diziyi ekrana düzgün bir matris formatında yazdırmak için sayaç sıfırlanır
            k = 1;

            // Çok boyutlu diziyi ekrana yazdırmak için foreach döngüsü kullanılıyor
            foreach (int x in dizi) // Dizi içerisindeki her bir elemanı sırayla al
            {
                // Eğer satırın son elemanına ulaşıldıysa
                if (k % 4 == 0)
                {
                    Console.Write(x + " "); // Elemanı yazdır
                    Console.WriteLine();   // Alt satıra geç
                }
                else // Aksi takdirde eleman aynı satırda yazdırılır
                {
                    Console.Write(x + " "); // Elemanı yazdır
                }
                k++; // Sayaç her elemanda bir artırılır
            }
        }
    }
}
