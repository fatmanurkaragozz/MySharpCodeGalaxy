using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class JaggedArrays
    {
        static void Main()
        {
            // Jagged (düzensiz) bir dizi tanımlanıyor.
            // Bu dizi 3 tane alt dizi içeriyor,ancak her alt dizi farklı uzunlukta olabilir.
            int[][] dizi = new int[3][];

            // Alt dizilere eleman ataması yapılıyor.
            // İlk alt dizi 2 eleman içeriyor.
            dizi[0] = new int[] { 1, 2 };

            // İkinci alt dizi 5 eleman içeriyor
            dizi[1] = new int[] { 3, 4, 5, 6, 7 };

            // Üçüncü alt dizi 3 eleman içeriyor.
            dizi[2] = new int[] { 8, 9, 0 };

            // Jagged dizinin elemanlarını ekrana yazdırmak için iç içe for döngüleri kullanılıyor.
            for(int i = 0; i < dizi.GetLength(0); i++) // İlk for döngüsü, alt dizileri dolaşır.
            {
                // Her bir alt dizinin elemanlarını dolaşmak için ikinci bir for döngüsü
                for(int j = 0; j < dizi[i].GetLength(0); j++)
                {
                    // Alt dizinin elemanlarını yazdırıyoruz
                    Console.WriteLine("dizi[{0}][{1}]={2}", i, j, dizi[i][j]);
                }
            }

            // Kullanıcın sonucu görmesi için program duraaklatılır.
            Console.ReadLine();
        }
    }
}
// C# dilinde "dizi[{0}][{1}]={2}" ifadesi, string biçimlendirme (string formatting) yöntemi 
// kullanılarak oluşturulmuş bir formattır. Buradaki {0}, {1}, ve {2}, yer tutucular (placeholders)
// olarak adlandırılır ve sonradan verilerle doldurulur.

// {0}, {1}, {2}: Bu ifadeler sırasıyla birinci, ikinci ve üçüncü parametrelere karşılık gelir.
// Bunlar, string.Format veya Console.WriteLine gibi metotlarda, virgül ile belirtilen parametrelerin 
// yerine yazılır.
 