using System;
using System.Collections.Generic;

class SpyOrganization
{
    // Giriş: Verilen uzunluk kadar Fibonacci serisini döndürür
    // Çıkış: İlk n Fibonacci sayısını içeren bir liste döndürür
    static List<int> FibonacciSerisi(int n)
    {
        List<int> fibonacci = new List<int> { 1, 1 }; // Fibonacci serisi başlangıcı

        // Kontrol: Fibonacci serisini oluşturmak için tekrar eden bir döngü
        for (int i = 2; i < n; i++)
        {
            // Matematik: Fibonacci kuralına göre önceki iki değerin toplamını hesapla
            fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);
        }

        return fibonacci; // Çıkış: Hesaplanmış Fibonacci serisini döndür
    }

    // Giriş: Bir sayının asal olup olmadığını belirler
    // Çıkış: Asal ise true, değilse false döndürür
    static bool AsalMi(int sayi)
    {
        if (sayi < 2) return false; // Kontrol: 2'den küçük sayılar asal olamaz

        // Kontrol: Asallık kontrolü için döngü
        for (int i = 2; i * i <= sayi; i++)
        {
            // Matematik: Sayının tam böleni olup olmadığını kontrol et
            if (sayi % i == 0) return false; // Sayı asal değilse false döndür
        }
        return true; // Sayı asal ise true döndür
    }

    // Giriş: Şifrelenmiş bir mesaj alır ve orijinal haline geri döndürür
    // Çıkış: Çözülmüş orijinal mesajı döndürür
    static string SifreCoz(string sifreliMesaj)
    {
        // Giriş: Fibonacci serisini, mesaj uzunluğuna göre hesapla
        List<int> fibonacci = FibonacciSerisi(sifreliMesaj.Length);
        char[] cozulmusMesaj = new char[sifreliMesaj.Length]; // Çıkış: Çözülmüş mesajı saklamak için dizi

        // Tekrar: Şifrelenmiş mesajın her karakterini işleme almak için döngü
        for (int i = 0; i < sifreliMesaj.Length; i++)
        {
            int asciiDegeri = (int)sifreliMesaj[i]; // Giriş: Şifrelenmiş karakterin ASCII değeri
            int fibonacciCarpani = fibonacci[i]; // Giriş: Pozisyona göre ilgili Fibonacci sayısı
            int modDegeri;

            // Kontrol: Pozisyon asal ise farklı mod işlemi uygula
            if (AsalMi(i + 1))
            {
                // Matematik: Pozisyon asal ise, ASCII değeri 100'e göre mod alınmış
                modDegeri = asciiDegeri % 100;
                // Matematik: Negatif mod durumunu düzeltme
                while (modDegeri < 0) modDegeri += 100;
            }
            else
            {
                // Matematik: Pozisyon asal değilse, ASCII değeri 256'ya göre mod alınmış
                modDegeri = asciiDegeri % 256;
                // Matematik: Negatif mod durumunu düzeltme
                while (modDegeri < 0) modDegeri += 256;
            }

            // Matematik: Fibonacci çarpanına göre ASCII değerini geri çöz
            int orjinalAsciiDegeri = modDegeri / fibonacciCarpani;

            // Çıkış: Orijinal ASCII değerini karaktere çevir ve diziye ekle
            cozulmusMesaj[i] = (char)orjinalAsciiDegeri;
        }

        // Çıkış: Çözülmüş mesajı string olarak döndür
        return new string(cozulmusMesaj);
    }

    static void Main()
    {
        // Giriş: Kullanıcıdan şifrelenmiş mesaj
        string sifreliMesaj = "şifrelenmiş mesaj burada";  // Şifrelenmiş mesajı buraya girin

        // Çıkış: Çözülmüş mesajı ekrana yazdır
        string cozulmusMesaj = SifreCoz(sifreliMesaj);
        Console.WriteLine("Çözülmüş Mesaj: " + cozulmusMesaj);

        Console.ReadLine();
    }

   

}
