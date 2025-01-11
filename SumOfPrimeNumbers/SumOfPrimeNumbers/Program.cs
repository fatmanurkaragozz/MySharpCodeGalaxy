using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfPrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan N sayısını al
            Console.Write("Bir N sayısı girin: ");
            int N = int.Parse(Console.ReadLine());

            int toplam = 0; // Asal sayıların toplamını tutacak değişken

            // 2'den N'e kadar olan sayılar için döngü
            for (int i = 2; i <= N; i++)
            {
                if (IsAsal(i)) // Sayının asal olup olmadığını kontrol et
                {
                    toplam += i; // Eğer asal ise toplam değişkenine ekle
                }
            }

            // Sonucu ekrana yazdır
            Console.WriteLine($"1 ile {N} arasındaki asal sayıların toplamı: {toplam}");
            Console.ReadLine();
        }

        // Asal sayıyı kontrol eden fonksiyon
        static bool IsAsal(int sayi)
        {
            // 1 ve daha küçük sayılar asal değildir
            if (sayi <= 1) return false;

            // 2'den sayının kareköküne kadar olan sayılarla kontrol et
            for (int i = 2; i * i <= sayi; i++)
            {
                if (sayi % i == 0) // Eğer sayi, i'ye tam bölünüyorsa asal değildir
                    return false;
            }
            return true; // Aksi halde asal
        }
    }
}
