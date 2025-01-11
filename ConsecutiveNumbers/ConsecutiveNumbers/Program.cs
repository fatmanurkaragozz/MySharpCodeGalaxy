using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsecutiveNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // GİRİŞ: Kullanıcıdan tam sayılar alıp listeye eklemek
            List<int> sayilar = new List<int>(); // Girilen sayıları saklamak için liste tanımlıyoruz.

            while (true) // Sonsuz döngü, kullanıcı 0 girene kadar devam eder
            {
                Console.Write("Tam sayı giriniz (Çıkmak için 0): ");
                int sayi = Convert.ToInt32(Console.ReadLine()); //  Kullanıcıdan giriş alıyoruz.

                if (sayi == 0) break; // ÇIKIŞ: Eğer kullanıcı 0 girerse döngü sonlanır.
                sayilar.Add(sayi); // GİRİŞ: Girilen sayıyı listeye ekliyoruz.
            }

            // KONTROL: lİSTE boş değilse işleme devam ediyoruz.
            if(sayilar.Count == 0)
            {
                Console.WriteLine("Hiç sayı girilmedi.");
                return; // Progrramı sonlandırıyoruz çünkü işlenecek sayı yok.
            }

            // Girişlerin kolay işlenmesi için listeyi sıralıyoruz.
            sayilar.Sort(); // KONTROL ve MATEMATİK: Sayıları küçükten büyüğe sıralıyoruz.

            // Ardışık grupları bulmak için başlangıç sayısını belirliyoruz.
            int baslangic = sayilar[0]; // İlk grubun başlangıç sayısı.
            bool ardisikGrupVar = false; // KONTROL: En az bir ardışık grup var mı ?

            // ÇIKIŞ ve KONTROL: Listeyi tarayıp ardışık sayıları kontrol ediyoruz
            for(int i = 1; i < sayilar.Count; i++)
            {
                // Eğer ardışık değilse grup bitmiş demektir
                if(sayilar[i] != sayilar[i - 1] + 1)
                {
                    if(baslangic != sayilar[i - 1]) // Eğer grup birden fazla sayıyı kapsıyorsa
                    {
                        Console.WriteLine($"{baslangic} - {sayilar[i - 1]}");
                        ardisikGrupVar = true; // Ardışık grup var
                    }

                    // Yeni bir grubun başlangıcını belirliyoruz.
                    baslangic = sayilar[i]; // MATEMATİK: Yeni başlangıç sayısı.
                }
               
            }

            // SON KONTROL: Döngü sonunda kalan son grubu yazdırıyoruz (eğer bir grup varsa).
            if(baslangic != sayilar[sayilar.Count - 1] && ardisikGrupVar) // MATEMATİK: Son grubun tek sayı mı olduğunu kontrol ediyoruz.
            {
                Console.WriteLine($"{baslangic} - {sayilar[sayilar.Count - 1]}"); // ÇIKIŞ: Kalan son grubu yazdır.
            }
            else if (ardisikGrupVar) // Eğer sadece bir sayı varsa ve ardışık grup bulunduysa, herhangi bir işlem yapma.
            {
                // Bu durum için çıktıya gerek yok, çümkü tek bir sayı ardışık grup oluşturmaz.
            }

            // Programın sonunda tüm çıktıları görmek için bekleme ekliyoruz.
            Console.WriteLine("Program tamamlandı. Çıkmak için Enter'a basın.");
            Console.ReadLine(); // Programın bitmeden önce kapanmaması için son bekleme.
            
        }
        
    }
}
