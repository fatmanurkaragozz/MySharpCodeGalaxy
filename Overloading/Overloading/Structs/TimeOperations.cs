using System;

namespace ZamanIslemleri
{
    // Zaman yapısını (struct) tanımlıyoruz.
    public struct Zaman
    {
        // Saat ve dakika özelliklerini tanımlıyoruz.
        public int Saat { get; private set; }
        public int Dakika { get; private set; }

        // Yapıcı metot (Constructor): Zaman nesnesi oluşturulurken geçerli saat ve dakika değerleri kontrol edilir.
        public Zaman(int saat, int dakika)
        {
            // Geçersiz saat (0-23 arasında olmalı) kontrolü yapıyoruz.
            if (saat < 0 || saat > 23)
            {
                // Geçersiz saat durumunda 0 atanır.
                saat = 0;
            }

            // Geçersiz dakika (0-59 arasında olmalı) kontrolü yapıyoruz.
            if (dakika < 0 || dakika > 59)
            {
                // Geçersiz dakika durumunda 0 atanır.
                dakika = 0;
            }

            // Saat ve dakika değerlerini ayarlıyoruz.
            Saat = saat;
            Dakika = dakika;
        }

        // Toplam dakika değerini döndüren metot.
        public int ToplamDakika()
        {
            // Saat * 60, saati dakikaya çevirir ve dakikayı ekleriz.
            return (Saat * 60) + Dakika;
        }

        // İki zaman nesnesi arasındaki farkı dakika cinsinden hesaplayan metot.
        public int Fark(Zaman diger)
        {
            // İlk zamanın toplam dakikasını alıyoruz.
            int buZamanToplam = this.ToplamDakika();

            // Diğer zamanın toplam dakikasını alıyoruz.
            int digerZamanToplam = diger.ToplamDakika();

            // İki zaman arasındaki farkı hesaplıyoruz.
            return Math.Abs(buZamanToplam - digerZamanToplam); // Mutlak değer alarak farkı pozitif yapıyoruz.
        }

        // Zaman bilgisini okunabilir şekilde döndüren metot.
        public override string ToString()
        {
            // Saat ve dakikayı "hh:mm" formatında döndürüyoruz.
            return $"{Saat:D2}:{Dakika:D2}";
        }
    }

    // Ana program sınıfı
    public class Program10
    {
        public static void Main()
        {
            // Zaman nesneleri oluşturuluyor
            Zaman zaman1 = new Zaman(14, 30);  // Geçerli bir zaman
            Zaman zaman2 = new Zaman(16, 45);  // Geçerli bir zaman
            Zaman zaman3 = new Zaman(25, 70);  // Geçersiz değerler (Bu zaman 00:00 olarak ayarlanacak)

            // Zaman bilgilerini ekrana yazdırıyoruz.
            Console.WriteLine("Zaman 1: " + zaman1);  // 14:30
            Console.WriteLine("Zaman 2: " + zaman2);  // 16:45
            Console.WriteLine("Geçersiz Zaman 3: " + zaman3);  // 00:00

            // Toplam dakika hesaplaması
            Console.WriteLine("Zaman 1'in toplam dakikası: " + zaman1.ToplamDakika());  // 870 dakika
            Console.WriteLine("Zaman 2'nin toplam dakikası: " + zaman2.ToplamDakika());  // 1005 dakika

            // İki zaman arasındaki farkı hesaplama
            Console.WriteLine("Zaman 1 ve Zaman 2 arasındaki fark: " + zaman1.Fark(zaman2) + " dakika");

            // Geçersiz değerlerin düzeltildiğini doğrulama
            Console.WriteLine("Geçersiz Zaman 3'ün toplam dakikası: " + zaman3.ToplamDakika());  // 0 dakika

            Console.ReadLine();
        }
    }
}
