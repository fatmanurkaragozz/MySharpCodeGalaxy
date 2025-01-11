using System;

namespace HomeworkClasses
{
    // Kişi bilgilerini tutan sınıf
    class AdresDefterSinifi
    {
        // Özellikler: Ad, Soyad ve Telefon Numarası
        public string Ad { get; private set; }              // Kişinin adı
        public string Soyad { get; private set; }           // Kişinin soyadı
        public string TelefonNumarasi { get; private set; } // Kişinin telefon numarası

        // Yapıcı Metot: Kişinin bilgilerini başlatır
        public AdresDefterSinifi(string ad, string soyad, string telefonNumarasi)
        {
            Ad = ad;                                       // Ad özelliğini gelen parametre ile başlat
            Soyad = soyad;                                 // Soyad özelliğini gelen parametre ile başlat
            TelefonNumarasi = telefonNumarasi;             // Telefon numarasını gelen parametre ile başlat
        }

        // Metot: Kişi bilgilerini döndürür
        public string KisiBilgisi()
        {
            // Tam adı ve telefon numarasını döndürür
            return $"Ad Soyad: {Ad} {Soyad}, Telefon Numarası: {TelefonNumarasi}";
        }
    }

    // Program sınıfı: Adres defteri uygulamasının başlangıç noktası
    class Program5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Adres Defteri ==="); // Giriş bilgisi ekrana yazdırılır

            string ad;        // Adı tutacak değişken
            string soyad;     // Soyadı tutacak değişken
            string telefon;   // Telefon numarasını tutacak değişken

            while (true) // Kontrol: Kullanıcı doğru bilgi girene kadar tekrar et
            {
                // Kullanıcıdan ad bilgisi alınır
                Console.Write("Adı giriniz: ");
                ad = Console.ReadLine();

                // Kullanıcıdan soyad bilgisi alınır
                Console.Write("Soyadı giriniz: ");
                soyad = Console.ReadLine();

                // Kullanıcıdan telefon numarası bilgisi alınır
                Console.Write("Telefon numarasını giriniz: ");
                telefon = Console.ReadLine();

                // Giriş Kontrolü: Bilgilerin boş bırakılmadığını kontrol eder
                if (!string.IsNullOrWhiteSpace(ad) &&
                    !string.IsNullOrWhiteSpace(soyad) &&
                    !string.IsNullOrWhiteSpace(telefon))
                {
                    break; // Bilgiler doğruysa döngüden çık
                }
                else
                {
                    // Hatalı girişte uyarı mesajı
                    Console.WriteLine("Hata: Tüm bilgileri eksiksiz giriniz.\n");
                }
            }

            // Yeni bir kişi oluşturulur
            AdresDefterSinifi kisi = new AdresDefterSinifi(ad, soyad, telefon);

            // Çıkış: Kullanıcıya başarılı işlem mesajı yazdırılır
            Console.WriteLine("\nKişi başarıyla kaydedildi!");
            Console.WriteLine("Kayıtlı Kişi Bilgileri:");

            // Metot kullanılarak kişi bilgisi ekrana yazdırılır
            Console.WriteLine(kisi.KisiBilgisi());

            Console.ReadLine(); // Programın sonlanmasını önlemek için bekletme
        }
    }
}
