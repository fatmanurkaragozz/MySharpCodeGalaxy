using System;

namespace HomeworkClasses
{
    // Araç kiralama sınıfı
    class AracKiralamaSinifi
    {
        // Özellikler
        public string Plaka { get; private set; }  // Aracın plakası
        public decimal GunlukUcret { get; private set; } // Günlük kiralama ücreti
        public bool MusaitMi { get; private set; } // Aracın müsaitlik durumu

        // Yapıcı Metot: Plaka ve günlük ücret bilgilerini başlatır, MusaitMi varsayılan olarak true
        public AracKiralamaSinifi(string plaka, decimal gunlukUcret)
        {
            // Giriş: Kullanıcıdan araç plaka bilgisi alınır
            Plaka = plaka;

            // Kontrol: Ücret negatif olamaz, sıfırdan büyük olmalıdır
            GunlukUcret = gunlukUcret > 0 ? gunlukUcret : 0; // Negatif ücret kabul edilmez

            // Varsayılan olarak araç müsait kabul edilir
            MusaitMi = true; // Aracın müsaitlik durumu başlangıçta 'true'
        }

        // Aracı kiralama metodu
        public void AraciKirala()
        {
            // Kontrol: Eğer araç müsaitse kiralanabilir
            if (MusaitMi)
            {
                MusaitMi = false; // Aracın müsaitlik durumu değişir, artık müsait değil
                Console.WriteLine($"Araç {Plaka} başarıyla kiralandı."); // Kiralama mesajı
            }
            else
            {
                // Çıkış: Araç zaten kiralandıysa, tekrar kiralanamaz
                Console.WriteLine($"Araç {Plaka} şu anda müsait değil."); // Müsaitlik durumu mesajı
            }
        }

        // Aracı teslim etme metodu
        public void AraciTeslimEt()
        {
            // Kontrol: Eğer araç teslim edilmemişse, teslim edilebilir
            if (!MusaitMi)
            {
                MusaitMi = true; // Aracın müsaitlik durumu değişir, artık müsait
                Console.WriteLine($"Araç {Plaka} başarıyla teslim edildi."); // Teslimat mesajı
            }
            else
            {
                // Çıkış: Araç zaten müsaitse teslim edilmesine gerek yok
                Console.WriteLine($"Araç {Plaka} zaten müsait."); // Müsaitlik durumu mesajı
            }
        }
    }

    // Program sınıfı: Araç kiralama uygulamasının başlangıç noktası
    class Program4
    {
        static void Main(string[] args)
        {
            // Giriş: Kullanıcıya uygulamanın başlangıcı hakkında bilgi verilir
            Console.WriteLine("=== Araç Kiralama Uygulaması ===");

            // Kullanıcıdan araç bilgileri alınır
            Console.Write("Aracın plakasını giriniz: ");
            string plaka = Console.ReadLine(); // Giriş: Aracın plakası alınır

            // Kullanıcıdan günlük kiralama ücreti alınır
            decimal gunlukUcret;
            while (true) // Kontrol: Kullanıcı geçerli bir ücret girene kadar devam et
            {
                Console.Write("Günlük kiralama ücretini giriniz: ");

                // Matematiksel adım: Kullanıcıdan alınan ücret değeri pozitif olmalı
                if (decimal.TryParse(Console.ReadLine(), out gunlukUcret) && gunlukUcret > 0)
                {
                    break; // Geçerli bir ücret girildiyse döngüden çık
                }
                else
                {
                    // Çıkış: Hatalı ücret girildiğinde kullanıcı bilgilendirilir
                    Console.WriteLine("Lütfen pozitif bir günlük ücret giriniz.");
                }
            }

            // Kiralık araç nesnesi oluşturulur
            AracKiralamaSinifi arac = new AracKiralamaSinifi(plaka, gunlukUcret);
            // Çıkış: Araç oluşturulduktan sonra bilgileri ekrana yazdırılır
            Console.WriteLine($"\nAraç oluşturuldu: {arac.Plaka}, Günlük Ücret: {arac.GunlukUcret:C}, Müsait: {arac.MusaitMi}");

            bool devam = true;

            // Tekrar: Kullanıcı "Çıkış" seçeneğini seçene kadar döngü devam eder
            while (devam)
            {
                // Giriş: Kullanıcıya işlem seçenekleri sunulur
                Console.WriteLine("\n1. Aracı Kirala");
                Console.WriteLine("2. Aracı Teslim Et");
                Console.WriteLine("3. Çıkış");
                Console.Write("Seçiminiz: ");

                int secim;
                // Kullanıcıdan seçim alınır
                if (int.TryParse(Console.ReadLine(), out secim))
                {
                    switch (secim) // Seçime göre işlem yapılır
                    {
                        case 1: // Aracı kirala
                            arac.AraciKirala();
                            break;

                        case 2: // Aracı teslim et
                            arac.AraciTeslimEt();
                            break;

                        case 3: // Çıkış yap
                            Console.WriteLine("Çıkış yapılıyor...");
                            devam = false; // Döngü sonlanır
                            break;

                        default: // Geçersiz seçim yapılırsa uyarı verilir
                            Console.WriteLine("Geçersiz bir seçim yaptınız. Lütfen tekrar deneyin.");
                            break;
                    }
                }
                else
                {
                    // Kontrol: Kullanıcı geçerli bir seçim girmezse uyarı verilir
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                }
            }

            // Çıkış: Programdan çıkış mesajı gösterilir
            Console.WriteLine("Uygulamadan çıktınız. İyi günler dileriz!");
        }
    }
}
