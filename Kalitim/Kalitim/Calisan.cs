using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalitim
{
    // Temel Calisan sınıfı
    public class Calisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public decimal Maas { get; set; }
        public string Pozisyon { get; set; }

        // BilgiYazdir metodu, türetilmiş sınıflar tarafından ezilecek
        public virtual void BilgiYazdir()
        {
            Console.WriteLine("Çalışan Bilgileri:");
            Console.WriteLine($"Ad: {Ad}");
            Console.WriteLine($"Soyad: {Soyad}");
            Console.WriteLine($"Maaş: {Maas} TL");
            Console.WriteLine($"Pozisyon: {Pozisyon}");
        }
    }

    // Yazilimci sınıfı, Calisan sınıfından türetiliyor
    public class Yazilimci : Calisan
    {
        public string YazilimDili { get; set; }

        // BilgiYazdir metodu override ediliyor
        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Yazılım Dili: {YazilimDili}");
        }
    }

    // Muhasebeci sınıfı, Calisan sınıfından türetiliyor
    public class Muhasebeci : Calisan
    {
        public string MuhasebeYazilimi { get; set; }

        // BilgiYazdir metodu override ediliyor
        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Muhasebe Yazılımı: {MuhasebeYazilimi}");
        }
    }

    public class Program2
    {
        public static void Main()
        {
            Console.WriteLine("Çalışan türünü seçin (1: Yazilimci, 2: Muhasebeci): ");
            int secim = int.Parse(Console.ReadLine());

            // Çalışan nesnesi tanımlanıyor
            Calisan calisan = null;

            // Kullanıcının seçimine göre nesne oluşturuluyor
            if (secim == 1)
            {
                calisan = new Yazilimci();
                Console.Write("Yazılım Dili: ");
                ((Yazilimci)calisan).YazilimDili = Console.ReadLine();
            }
            else if (secim == 2)
            {
                calisan = new Muhasebeci();
                Console.Write("Muhasebe Yazılımı: ");
                ((Muhasebeci)calisan).MuhasebeYazilimi = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
                return;
            }

            // Ortak bilgiler alınıyor
            Console.Write("Ad: ");
            calisan.Ad = Console.ReadLine();

            Console.Write("Soyad: ");
            calisan.Soyad = Console.ReadLine();

            Console.Write("Maaş: ");
            calisan.Maas = decimal.Parse(Console.ReadLine());

            Console.Write("Pozisyon: ");
            calisan.Pozisyon = Console.ReadLine();

            // Bilgiler yazdırılıyor
            Console.WriteLine("\nÇalışan Bilgileri:\n");
            calisan.BilgiYazdir();

            Console.ReadLine();
        }
    }
}
