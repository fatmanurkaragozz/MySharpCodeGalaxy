using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalitim
{
    // IYayinci arayüzü, abone ekleme, çıkarma ve listeleme metodlarını içerir.
    public interface IYayinci
    {
        // Yeni bir abone eklemek için metod
        void AboneEkle(IAbone abone);

        // Bir aboneyi çıkarmak için metod
        void AboneCikarma(IAbone abone);

        // Mevcut aboneleri listelemek için metod
        void AboneListele();

        // Tüm abonelere bildirim göndermek için metod
        void BildirimGonder(string mesaj);
    }

    // IAbone arayüzü, abonenin bilgi almasını sağlar
    public interface IAbone
    {
        // Yayıncıdan gelen bildirimleri almak için metod
        void BilgiAl(string mesaj);
    }

    // Yayinci sınıfı, IYayinci arayüzünü uygular ve aboneleri yönetir
    public class Yayinci : IYayinci
    {
        // Aboneleri saklamak için bir liste
        private List<IAbone> aboneler = new List<IAbone>();

        // Yeni bir abone ekler
        public void AboneEkle(IAbone abone)
        {
            aboneler.Add(abone);
            Console.WriteLine($"{abone.ToString()} abonelere eklendi.");
        }

        // Bir aboneyi listeden çıkarır
        public void AboneCikarma(IAbone abone)
        {
            aboneler.Remove(abone);
            Console.WriteLine($"{abone.ToString()} abonelerden çıkarıldı.");
        }

        // Tüm aboneleri listeleyen metod
        public void AboneListele()
        {
            Console.WriteLine("Mevcut Aboneler:");
            foreach (var abone in aboneler)
            {
                Console.WriteLine(abone.ToString());
            }
        }

        // Tüm abonelere bildirim gönderir
        public void BildirimGonder(string mesaj)
        {
            Console.WriteLine($"\nYayıncı bir güncelleme gönderiyor: {mesaj}");
            foreach (var abone in aboneler)
            {
                abone.BilgiAl(mesaj);
            }
        }
    }

    // Abone sınıfı, IAbone arayüzünü uygular ve bildirimleri alır
    public class Abone : IAbone
    {
        // Abonenin adı
        public string Ad { get; private set; }

        // Yapıcı metod (Constructor)
        public Abone(string ad)
        {
            Ad = ad;
        }

        // Bildirim alındığında ekrana yazdıran metod
        public void BilgiAl(string mesaj)
        {
            Console.WriteLine($"{Ad} adlı aboneye bildirim: {mesaj}");
        }

        // Abonenin adını döndüren metod
        public override string ToString()
        {
            return Ad;
        }
    }

    // Program sınıfı, Observer Pattern'in çalışmasını test eden ana sınıftır.
    public class Program4
    {
        public static void Main(string[] args)
        {
            // Yayıncı oluşturuluyor
            Yayinci yayinci = new Yayinci();

            // Aboneler oluşturuluyor
            Abone abone1 = new Abone("Ali");
            Abone abone2 = new Abone("Ayşe");
            Abone abone3 = new Abone("Mehmet");

            // Aboneler yayına ekleniyor
            yayinci.AboneEkle(abone1);
            yayinci.AboneEkle(abone2);
            yayinci.AboneEkle(abone3);

            // Tüm abonelere bildirim gönderiliyor
            yayinci.BildirimGonder("Yeni kampanya başladı!");

            // Bir abone çıkarılıyor
            yayinci.AboneCikarma(abone2);

            // Abonelik sonrası tekrar bildirim gönderiliyor
            yayinci.BildirimGonder("Yeni ürünler eklendi!");

            Console.ReadLine();
        }
    }
}
