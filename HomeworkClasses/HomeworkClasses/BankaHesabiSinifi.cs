using System;

namespace HomeworkClasses
{
    class BankaHesabiSinifi
    {
        // Özellikler: Hesap numarası ve bakiye
        // HesapNumarasi yalnızca okunabilir.
        public string HesapNumarasi { get; private set; }

        // Bakiye yalnızca sınıf içerisinden değiştirilebilir.
        public decimal Bakiye { get; private set; }

        // Yapıcı Metot: Hesap numarasını ve başlangıç bakiyesini başlatır.
        public BankaHesabiSinifi(string hesapNumarasi, decimal ilkBakiye)
        {
            HesapNumarasi = hesapNumarasi;

            // Negatif bakiye kabul edilmez. İlk bakiye 0 veya pozitif bir değer olmalıdır.
            Bakiye = ilkBakiye >= 0 ? ilkBakiye : 0;
        }

        // Metot: Para yatırma işlemi gerçekleştirir.
        public void ParaYatir(decimal miktar)
        {
            // Kontrol: Yatırılacak miktar sıfırdan büyük olmalıdır.
            if (miktar > 0)
            {
                // Bakiye artırılır.
                Bakiye += miktar;
                Console.WriteLine($"{miktar:C} başarıyla yatırıldı. Güncel bakiye: {Bakiye:C}");
            }
            else
            {
                // Geçersiz giriş uyarısı.
                Console.WriteLine("Yatırılacak miktar sıfırdan büyük olmalıdır.");
            }
        }

        // Metot: Para çekme işlemi gerçekleştirir.
        public void ParaCek(decimal miktar)
        {
            // Kontrol: Çekilecek miktar sıfırdan büyük olmalıdır.
            if (miktar > 0)
            {
                // Kontrol: Yeterli bakiye varsa çekme işlemi yapılır.
                if (Bakiye >= miktar)
                {
                    // Bakiye azaltılır.
                    Bakiye -= miktar;
                    Console.WriteLine($"{miktar:C} başarıyla çekildi. Güncel bakiye: {Bakiye:C}");
                }
                else
                {
                    // Bakiye yetersiz uyarısı.
                    Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
                }
            }
            else
            {
                // Geçersiz giriş uyarısı.
                Console.WriteLine("Çekilecek miktar sıfırdan büyük olmalıdır.");
            }
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            // Giriş: Kullanıcıya başlangıç bilgilerini göster
            Console.WriteLine("=== Banka Hesabı Uygulaması ===");

            // Hesap bilgilerini başlat (örnek hesap)
            BankaHesabiSinifi hesap = new BankaHesabiSinifi("TR1234567890", 1000m);
            Console.WriteLine($"Hesap Numarası: {hesap.HesapNumarasi}");
            Console.WriteLine($"Başlangıç Bakiyesi: {hesap.Bakiye:C}\n");

            // Kullanıcının işlemleri seçebilmesi için bir döngü başlatılır.
            bool devam = true;
            while (devam)
            {
                // Kullanıcıya işlem seçenekleri sunulur.
                Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçin:");
                Console.WriteLine("1. Para Yatır");
                Console.WriteLine("2. Para Çek");
                Console.WriteLine("3. Çıkış");
                Console.Write("Seçiminiz: ");

                // Kullanıcıdan seçim al
                int secim;
                if (int.TryParse(Console.ReadLine(), out secim))
                {
                    // Kullanıcının yaptığı seçime göre işlem yapılır.
                    switch (secim)
                    {
                        case 1: // Para yatırma işlemi
                            Console.Write("Yatırmak istediğiniz miktarı girin: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal yatirMiktar))
                            {
                                hesap.ParaYatir(yatirMiktar);
                            }
                            else
                            {
                                // Geçersiz miktar uyarısı
                                Console.WriteLine("Geçersiz miktar girdiniz.");
                            }
                            break;

                        case 2: // Para çekme işlemi
                            Console.Write("Çekmek istediğiniz miktarı girin: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal cekMiktar))
                            {
                                hesap.ParaCek(cekMiktar);
                            }
                            else
                            {
                                // Geçersiz miktar uyarısı
                                Console.WriteLine("Geçersiz miktar girdiniz.");
                            }
                            break;

                        case 3: // Çıkış işlemi
                            Console.WriteLine("Çıkış yapılıyor...");
                            devam = false; // Döngü sonlandırılır
                            break;

                        default:
                            // Geçersiz seçim uyarısı
                            Console.WriteLine("Geçersiz seçim yaptınız.");
                            break;
                    }
                }
                else
                {
                    // Sayı dışında bir giriş yapıldığında uyarı
                    Console.WriteLine("Geçersiz seçim yaptınız.");
                }
            }

            // Çıkış mesajı
            Console.WriteLine("Bankacılık sisteminden çıktınız. İyi günler dileriz!");
        }
    }
}
