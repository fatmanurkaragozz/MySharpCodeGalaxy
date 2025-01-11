using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkClasses
{
    class KutuphaneSinifi
    {
        public string Ad { get; private set; }          // Kitabın adı
        public string Yazar { get; private set; }       // Kitabın yazarı

        // Yapıcı metot: Kitap adı ve yazarını başlatır
        public KutuphaneSinifi(string ad, string yazar)
        {
            Ad = ad;
            Yazar = yazar;
        }

        // Kitap bilgilerini döndürür
        public override string ToString()
        {
            return $"Kitap Adı: {Ad}, Yazar: {Yazar}";
        }
    }

    // Kütüphane sınıfı: Kitap ekleme ve listeleme işlemleri için
    class Kutuphane
    {
        // Kitaplar özelliği: Kütüphanedeki kitapların listesini tutar
        public List<KutuphaneSinifi> Kitaplar { get; private set; }

        // Yapıcı metot: Kitap listesi boş olarak başlatılır
        public Kutuphane()
        {
            Kitaplar = new List<KutuphaneSinifi>();
        }

        // Kitap ekleme metodu
        public void KitapEkle(KutuphaneSinifi yeniKitap)
        {
            // Kontrol: Kitap boş isim veya yazar ile eklenemez
            if (string.IsNullOrWhiteSpace(yeniKitap.Ad) || string.IsNullOrWhiteSpace(yeniKitap.Yazar))
            {
                Console.WriteLine("Kitap adı ve yazar bilgisi boş olamaz.");
                return; // Hatalı giriş olduğunda ekleme yapılmaz
            }

            this.Kitaplar.Add(yeniKitap); // Kitap kütüphaneye ekleniyor
            Console.WriteLine($"Kitap eklendi: {yeniKitap}");
        }

        // Kitapları listeleme metodu
        public void KitaplariListele()
        {
            Console.WriteLine("\nKütüphanedeki Kitaplar:");
            // Matematiksel Kontrol: Kitap sayısı sıfır ise boş kütüphane mesajı verilir.
            if (Kitaplar.Count == 0)
            {
                Console.WriteLine("Kütüphanede hiç kitap bulunmuyor.");
            }
            else
            {
                foreach (var kitap in this.Kitaplar)
                {
                    Console.WriteLine(kitap); // Her bir kitabın bilgisi yazdırılır
                }
            }
        }
    }

    // Program sınıfı: Uygulamanın başlangıç noktası
    class Program6
    {
        static void Main(string[] args)
        {
            // Giriş: Kullanıcıya program hakkında bilgi verilir.
            Console.WriteLine("=== Kütüphane Yönetimi ===");

            // Yeni bir kütüphane oluştur
            Kutuphane kutuphane = new Kutuphane();

            // Kullanıcıdan birkaç kitap bilgisi al ve ekle
            for (int i = 0; i < 2; i++)
            {
                // Giriş: Kullanıcıdan kitap adı ve yazar adı istenir.
                Console.Write("\nKitap Adını Giriniz: ");
                string ad = Console.ReadLine();

                Console.Write("Yazar Adını Giriniz: ");
                string yazar = Console.ReadLine();

                // Matematiksel Kontrol: Kitap adı ve yazar bilgisi boş olamaz.
                if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(yazar))
                {
                    // Geçersiz giriş uyarısı
                    Console.WriteLine("Kitap adı veya yazar adı boş olamaz. Tekrar deneyin.");
                    i--; // Tekrar kitap eklenmesi istenecektir.
                    continue; // Bu adımda döngü tekrar başlatılır.
                }

                // Yeni kitap oluştur ve kütüphaneye ekle
                KutuphaneSinifi kitap = new KutuphaneSinifi(ad, yazar);
                kutuphane.KitapEkle(kitap);
            }

            // Tüm kitapları listele
            kutuphane.KitaplariListele();

            // Çıkış: Programdan çıkış yapılır.
            Console.ReadLine();
        }
    }
}
