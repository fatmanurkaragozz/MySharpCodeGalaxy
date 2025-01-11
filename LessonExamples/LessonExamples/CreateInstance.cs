using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class CreateInstance
    {
        static void Main()
        {
            // Array.CreateInstance() metodu kullanılarak 3 boyutlu bir dizi oluşturuluyor
            // Dizi 5*4*3 boyutlarına sahip.
            // 5: birinci boyut (i), 4: ikinci boyut (j), 3: üçüncü boyut (k).
            Array dizi = Array.CreateInstance(typeof(int), 5, 4, 3);

            // Rastgele sayılar üretmek için Random sınıfından bir nesne oluşturluyor.
            Random r = new Random();

            // Dizinin birinci boyutunu dolaşmak için ilk for döngüsü.
            for(int i=0; i< dizi.GetLength(0); i++) // GetLength(0) => Birinci boyutun uzuznluğu (5).
            {
                // Dizinin ikinci boyutunu dolaşmak için ikinci for döngüsü.
                for (int j = 0; j<dizi.GetLength(1); j++)  // GetLength(1) => İkinci boyutun uzuznluğu (4).
                {
                    // Dizinin üçüncü boyutunu dolaşmak için üçüncü for döngüsü
                    for(int k=0; k < dizi.GetLength(2); k++)  // GetLength(2) => Üçüncü boyutun uzuznluğu (3).
                    {
                        // Diziye rastgele bir değer atanıyor (10 ile 99 arasında bir sayı).
                        dizi.SetValue(r.Next(10, 100), i, j, k);

                        // Dizinin elemanının indeksi (i, j, k) ve değeri ekrana yazdırılıyor.
                        Console.WriteLine("dizi[{0},{1},{2}]={3,3}",
                            i, j, k, dizi.GetValue(i, j, k));
                        // {3.3}: Değer, 3 karakter genişliğinde hizalanarak yazdırılır.
                    }
                }
            }

            Console.ReadLine();
        }

        
    }
}
