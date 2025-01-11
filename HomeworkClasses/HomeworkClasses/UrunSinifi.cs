using System;

namespace HomeworkClasses
{
    class UrunSinifi
    {
        // Özellikler
        public string Ad { get; private set; } // Ürün adı
        public decimal Fiyat { get; private set; } // Ürün fiyatı

        // İndirim özelliği (0-50% arasında sınırlandırılmıştır)
        private decimal _indirim;

        public decimal Indirim
        {
            get { return _indirim; }
            set
            {
                // İndirim değeri 0 ile 50 arasında olmalı
                if (value >= 0 && value <= 50)
                {
                    _indirim = value;
                }
                else
                {
                    // Kontrol: Geçersiz indirim değeri girildiğinde uyarı verilir
                    Console.WriteLine("İndirim 0 ile 50 arasında olmalıdır. Değer atanmadı.");
                }
            }
        }

        // Yapıcı Metot: Ürün adı ve fiyat bilgileri başlatılır
        public UrunSinifi(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat > 0 ? fiyat : 0; // Matematiksel kontrol: Fiyat negatif olamaz
            Indirim = 0; // Varsayılan indirim %0
        }

        // Metot: İndirimli fiyatı hesaplar ve döndürür
        public decimal IndirimliFiyat()
        {
            // Matematiksel işlem: İndirim oranına göre indirimli fiyat hesaplanır
            decimal indirimliFiyat = Fiyat - (Fiyat * Indirim / 100);
            return indirimliFiyat;
        }
    }

    class Program3
    {
        static void Main(string[] args)
        {
            // Giriş: Kullanıcıya program hakkında bilgi verilir
            Console.WriteLine("=== Ürün Sınıfı Uygulaması ===");

            // Kullanıcıdan ürün bilgileri alınır
            Console.Write("Ürün adı giriniz: ");
            string urunAdi = Console.ReadLine();

            Console.Write("Ürün fiyatı giriniz: ");
            decimal urunFiyati;
            // Kontrol: Kullanıcıdan alınan fiyat bilgisi geçerli olmalıdır (pozitif sayı)
            while (!decimal.TryParse(Console.ReadLine(), out urunFiyati) || urunFiyati <= 0)
            {
                Console.WriteLine("Lütfen pozitif bir sayı giriniz.");
                Console.Write("Ürün fiyatı giriniz: ");
            }

            // Ürün oluşturulur
            UrunSinifi urun = new UrunSinifi(urunAdi, urunFiyati);
            Console.WriteLine($"\nÜrün oluşturuldu: {urun.Ad}, Fiyat: {urun.Fiyat:C}");

            bool devam = true;
            while (devam)
            {
                // Kullanıcıya işlem seçenekleri sunulur
                Console.WriteLine("\n1. İndirim Ayarla");
                Console.WriteLine("2. İndirimli Fiyatı Görüntüle");
                Console.WriteLine("3. Çıkış");
                Console.Write("Seçiminiz: ");

                int secim;
                // Kontrol: Kullanıcıdan alınan seçim geçerli olmalı
                if (int.TryParse(Console.ReadLine(), out secim))
                {
                    switch (secim)
                    {
                        case 1: // İndirim ayarla
                            Console.Write("İndirim oranını giriniz (%0-50): ");
                            decimal indirimOrani;
                            // Kontrol: Kullanıcıdan alınan indirim oranı 0 ile 50 arasında olmalı
                            while (!decimal.TryParse(Console.ReadLine(), out indirimOrani) || indirimOrani < 0 || indirimOrani > 50)
                            {
                                Console.WriteLine("Lütfen 0 ile 50 arasında bir değer giriniz.");
                                Console.Write("İndirim oranını giriniz: ");
                            }
                            urun.Indirim = indirimOrani; // İndirim oranı güncelleniyor
                            Console.WriteLine($"İndirim başarıyla ayarlandı: %{urun.Indirim}");
                            break;

                        case 2: // İndirimli fiyatı göster
                            decimal indirimliFiyat = urun.IndirimliFiyat();
                            // Matematiksel işlem: İndirimli fiyat hesaplanıp ekrana yazdırılır
                            Console.WriteLine($"İndirimli fiyat: {indirimliFiyat:C}");
                            break;

                        case 3: // Çıkış
                            Console.WriteLine("Çıkış yapılıyor...");
                            devam = false; // Döngü sonlandırılır
                            break;

                        default: // Geçersiz seçim
                            Console.WriteLine("Geçersiz seçim yaptınız. Lütfen tekrar deneyin.");
                            break;
                    }
                }
                else
                {
                    // Kontrol: Geçersiz giriş yapıldığında uyarı verilir
                    Console.WriteLine("Geçersiz giriş yaptınız. Lütfen bir sayı giriniz.");
                }
            }

            // Çıkış: Programdan çıkıldığında mesaj gösterilir
            Console.WriteLine("Uygulamadan çıktınız. İyi günler dileriz!");
        }
    }
}
