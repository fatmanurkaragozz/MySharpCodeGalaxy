using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalitim
{
    // Temel Hayvan sınıfı
    public class Hayvan
    {
        public string Ad { get; set; } // Hayvanın adı
        public string Tur { get; set; } // Hayvanın türü
        public int Yas { get; set; } // Hayvanın yaşı

        // Sanal (virtual) Ses çıkar metodu
        public virtual void SesCikar()
        {
            Console.WriteLine("Hayvan ses çıkarıyor.");
        }

        // Hayvanın bilgilerini yazdıran metot
        public virtual void BilgileriYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Tür: {Tur}, Yaş: {Yas}");
        }
    }

    // Memeli sınıfı, Hayvan sınıfından türetilmiştir
    public class Memeli : Hayvan
    {
        public string TuyRengi { get; set; } // Memelinin tüy rengi

        // SesCikar metodunu memelilere özgü olarak ezme
        public override void SesCikar()
        {
            Console.WriteLine("Memeli: Hırlama sesi çıkarıyor.");
        }

        // Memeliye özgü bilgileri yazdırma
        public override void BilgileriYazdir()
        {
            base.BilgileriYazdir();
            Console.WriteLine($"Tüy Rengi: {TuyRengi}");
        }
    }

    // Kuş sınıfı, Hayvan sınıfından türetilmiştir
    public class Kus : Hayvan
    {
        public double KanatGenisligi { get; set; } // Kuşun kanat genişliği

        // SesCikar metodunu kuşlara özgü olarak ezme
        public override void SesCikar()
        {
            Console.WriteLine("Kuş: Cik cik sesi çıkarıyor.");
        }

        // Kuşa özgü bilgileri yazdırma
        public override void BilgileriYazdir()
        {
            base.BilgileriYazdir();
            Console.WriteLine($"Kanat Genişliği: {KanatGenisligi} cm");
        }
    }
    // Program sınıfı, kullanıcıdan veri alır ve işlemleri gerçekleştirir
    public class Program3
    {
        public static void Main()
        {
            Console.WriteLine("Hayvan türünü seçin (1: Memeli, 2: Kuş): ");
            int secim = int.Parse(Console.ReadLine());

            Hayvan hayvan = null;

            if (secim == 1)
            {
                // Memeli bilgileri alınıyor
                hayvan = new Memeli();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());
                Console.Write("Tüy Rengi: ");
                ((Memeli)hayvan).TuyRengi = Console.ReadLine();
            }
            else if (secim == 2)
            {
                // Kuş bilgileri alınıyor
                hayvan = new Kus();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());
                Console.Write("Kanat Genişliği: ");
                ((Kus)hayvan).KanatGenisligi = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
                return;
            }

            // Hayvan bilgileri ve sesi yazdırılıyor
            Console.WriteLine("Hayvan Bilgileri:");
            hayvan.BilgileriYazdir();
            hayvan.SesCikar();

            Console.ReadLine();
        }
    }
}
