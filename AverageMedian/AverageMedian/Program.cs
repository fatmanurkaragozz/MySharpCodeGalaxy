using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageMedian
{
    class Program
    {
        static void Main(string[] args)
        {
            // GİRİŞ: Kullanıcıdan pozitif tam sayılar alıp listeye eklemek
            List<int> sayilar = new List<int>(); // Girilen sayıları saklamak için liste

            while (true) // TEKRAR: 0 girilene kadar döngü devam eder
            {
                Console.Write("Pozitif tam sayı giriniz (Çıkmak için 0): ");
                int sayi = Convert.ToInt32(Console.ReadLine()); // Kullanıcıdan sayı al

                if (sayi == 0) // KONTROL: Kullanıcı çıkmak için 0 girdi mi?
                {
                    break; // Eğer evet, döngüden çık
                }

                if (sayi > 0) // KONTROL: Sadece pozitif sayılar eklenir
                {
                    sayilar.Add(sayi); // Pozitifse listeye ekle
                }
                else
                {
                    Console.WriteLine("Lütfen pozitif bir tam sayı giriniz."); // Hata mesajı
                }
            }

            // ÇIKIŞ: Kullanıcıdan alınan sayıları ekrana yazdır
            Console.WriteLine("\nGirilen Sayılar:");
            foreach (int s in sayilar) // Liste içindeki her sayı için
            {
                Console.Write(s + " "); // Sayıyı ekrana yaz
            }

            // MATEMATİK: Ortalama ve medyan hesaplama
            if (sayilar.Count > 0) // KONTROL: Liste boş değilse
            {
                double ortalama = sayilar.Average(); // ORTALAMA: Liste elemanlarının ortalamasını al
                Console.WriteLine($"\nOrtalama: {ortalama}");

                sayilar.Sort(); // Medyan hesaplamak için listeyi sırala
                double medyan = MedyanHesapla(sayilar); // Medyanı hesapla
                Console.WriteLine($"Medyan: {medyan}"); // Medyanı yazdır
            }
            else
            {
                Console.WriteLine("\nHerhangi bir sayı girilmedi."); // Liste boşsa uyarı ver
            }

            Console.ReadLine(); // Programın kapanmasını engelle
        }

        // Medyan hesaplama fonksiyonu
        static double MedyanHesapla(List<int> sayilar)
        {
            int n = sayilar.Count; // Listedeki eleman sayısı

            if (n % 2 == 1) // KONTROL: Eleman sayısı tekse
            {
                return sayilar[n / 2]; // Ortadaki eleman medyan olur
            }
            else // Eleman sayısı çiftse
            {
                // MATEMATİK: Ortadaki iki elemanın ortalamasını al
                return (sayilar[n / 2 - 1] + sayilar[n / 2]) / 2.0;
            }
        }
    }
}
