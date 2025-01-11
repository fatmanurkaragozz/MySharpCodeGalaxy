using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalitim
{
    // Temel Hesap sınıfı
    public class Hesap
    {
        public string HesapNumarasi { get; set; }
        public string HesapSahibi { get; set; }
        public decimal Bakiye { get; set; }

        // Hesaba para yatırma metodu
        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Yeni Bakiye: {Bakiye} TL");
        }

        // Hesaptan para çekme metodu
        public virtual void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Yeni Bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        // Hesap bilgilerini yazdıran metod
        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Hesap No: {HesapNumarasi}\nHesap Sahibi: {HesapSahibi}\nBakiye: {Bakiye} TL");
        }
    }

    // Vadesiz Hesap sınıfı
    public class VadesizHesap : Hesap
    {
        public decimal EkHesapLimiti { get; set; }

        // Vadesiz hesap için para çekme metodu, ek hesap limiti kullanılabilir
        public override void ParaCek(decimal miktar)
        {
            if (Bakiye + EkHesapLimiti >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Yeni Bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Ek hesap limitiniz dahil yetersiz bakiye!");
            }
        }
    }

    // Vadeli Hesap sınıfı
    public class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; }
        public decimal FaizOrani { get; set; }
        private bool VadeDolduMu = false;

        // Vadeli hesap için para çekme, vade dolmadan çekilemez
        public override void ParaCek(decimal miktar)
        {
            if (VadeDolduMu)
            {
                base.ParaCek(miktar);
            }
            else
            {
                Console.WriteLine("Vade dolmadan para çekilemez!");
            }
        }

        // Vadeyi tamamlayarak faiz getirisi ekler
        public void VadeTamamla()
        {
            VadeDolduMu = true;
            decimal faizGetirisi = Bakiye * (FaizOrani / 100);
            Bakiye += faizGetirisi;
            Console.WriteLine($"Vade tamamlandı! Faiz getirisi: {faizGetirisi} TL. Yeni Bakiye: {Bakiye} TL");
        }
    }

    // Program sınıfı
    public class Program5
    {
        public static void Main()
        {
            // Kullanıcıdan hesap türünü seçmesini iste
            Console.WriteLine("Hesap türünü seçin (1: Vadesiz Hesap, 2: Vadeli Hesap): ");
            int secim = int.Parse(Console.ReadLine());

            Hesap hesap;

            // Seçime göre hesap oluştur
            if (secim == 1)
            {
                hesap = new VadesizHesap { EkHesapLimiti = 1000 };
            }
            else
            {
                hesap = new VadeliHesap { VadeSuresi = 12, FaizOrani = 10 };
            }

            // Hesap bilgilerini ayarla
            hesap.HesapNumarasi = "12345678";
            hesap.HesapSahibi = "Ahmet Yılmaz";
            hesap.Bakiye = 5000;

            // Hesap bilgilerini yazdır ve işlemleri gerçekleştir
            hesap.BilgiYazdir();
            hesap.ParaYatir(2000);
            hesap.ParaCek(3000);

            // Eğer vadeli hesapsa, vade tamamla ve para çek
            if (hesap is VadeliHesap vadeli)
            {
                vadeli.VadeTamamla();
                vadeli.ParaCek(1000);
            }

            // Son durumda hesap bilgilerini yazdır
            hesap.BilgiYazdir();
            Console.ReadLine();
        }
    }
}
