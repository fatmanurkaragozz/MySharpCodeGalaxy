using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalitim
{
    using System;

    namespace BankaHesapYonetimSistemi
    {
        // 1. Soyut Hesap sınıfı
        // Bu sınıf tüm banka hesapları için temel özellikler ve metotları tanımlar.
        public abstract class Hesap
        {
            // Hesap numarası ve bakiye gibi temel özellikler
            public string HesapNo { get; set; }
            public decimal Bakiye { get; set; }

            // Para yatırma işlemi metodu (türev sınıflarda kullanılmak üzere soyut)
            public abstract void ParaYatir(decimal miktar);

            // Para çekme işlemi metodu (türev sınıflarda kullanılmak üzere soyut)
            public abstract void ParaCek(decimal miktar);
        }

        // 2. BirikimHesabi sınıfı, Hesap sınıfından türetilir
        // Birikim hesabına özel faiz oranı gibi bir özellik ekler.
        public class BirikimHesabi : Hesap
        {
            // Faiz oranı özelliği
            public decimal FaizOrani { get; set; }

            // Para yatırma işlemi, faizi hesaplar
            public override void ParaYatir(decimal miktar)
            {
                Bakiye += miktar;  // İlk olarak miktarı bakiyeye ekleriz.
                decimal faiz = Bakiye * FaizOrani;  // Faiz hesaplanır.
                Bakiye += faiz;  // Faiz bakiyeye eklenir.
                Console.WriteLine($"Birikim hesabına {miktar:C} yatırıldı ve {faiz:C} faiz eklendi.");
            }

            // Para çekme işlemi, sadece bakiyeden çekme yapar.
            public override void ParaCek(decimal miktar)
            {
                if (Bakiye >= miktar)
                {
                    Bakiye -= miktar;
                    Console.WriteLine($"Birikim hesabından {miktar:C} çekildi.");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye.");
                }
            }
        }

        // 2. VadesizHesap sınıfı, Hesap sınıfından türetilir
        // Vadesiz hesaplarda işlem ücreti uygulanır.
        public class VadesizHesap : Hesap
        {
            // Vadesiz hesaba özel işlem ücreti
            public decimal IslemUcreti { get; set; }

            // Para yatırma işlemi, sadece bakiyeyi artırır.
            public override void ParaYatir(decimal miktar)
            {
                Bakiye += miktar;
                Console.WriteLine($"Vadesiz hesaba {miktar:C} yatırıldı.");
            }

            // Para çekme işlemi, işlem ücreti ekler.
            public override void ParaCek(decimal miktar)
            {
                decimal toplamTutar = miktar + IslemUcreti;  // Çekilen miktar ve işlem ücreti toplamı.
                if (Bakiye >= toplamTutar)
                {
                    Bakiye -= toplamTutar;
                    Console.WriteLine($"Vadesiz hesaptan {miktar:C} çekildi, işlem ücreti: {IslemUcreti:C}.");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye.");
                }
            }
        }

        // 3. IBankaHesabi arayüzü
        // Bu arayüz, banka hesaplarının ortak özelliklerini ve metodlarını tanımlar.
        public interface IBankaHesabi
        {
            // Hesap açılış tarihi özelliği
            DateTime HesapAcilisTarihi { get; set; }

            // Hesap özeti metodunu tanımlar
            void HesapOzeti();
        }

        // 4. BankaHesabi sınıfı, IBankaHesabi arayüzünü implement eder
        public class BankaHesabi : IBankaHesabi
        {
            // Hesap açılış tarihi
            public DateTime HesapAcilisTarihi { get; set; }

            // Hesap özetini yazdıran metod
            public void HesapOzeti()
            {
                Console.WriteLine($"Hesap Açılış Tarihi: {HesapAcilisTarihi.ToShortDateString()}");
            }
        }

        // Program sınıfı, sistemin çalışmasını test eder.
        public class Program7
        {
            public static void Main(string[] args)
            {
                // BirikimHesabi türünden bir hesap oluşturuyoruz.
                BirikimHesabi birikimHesabi = new BirikimHesabi
                {
                    HesapNo = "B12345",
                    Bakiye = 1000,  // Başlangıç bakiyesi
                    FaizOrani = 0.05m  // %5 faiz oranı
                };

                // VadesizHesap türünden bir hesap oluşturuyoruz.
                VadesizHesap vadesizHesap = new VadesizHesap
                {
                    HesapNo = "V67890",
                    Bakiye = 5000,  // Başlangıç bakiyesi
                    IslemUcreti = 10  // 10 TL işlem ücreti
                };

                // IBankaHesabi arayüzünü implement eden BankaHesabi nesnesi
                BankaHesabi bankaHesabi = new BankaHesabi
                {
                    HesapAcilisTarihi = DateTime.Now
                };

                // Hesap özetini yazdırıyoruz.
                bankaHesabi.HesapOzeti();

                // Birikim hesabına işlem yapıyoruz.
                Console.WriteLine("\nBirikim Hesabı İşlemleri:");
                birikimHesabi.ParaYatir(500);
                birikimHesabi.ParaCek(200);
                Console.WriteLine($"Birikim Hesabı Bakiyesi: {birikimHesabi.Bakiye:C}");

                // Vadesiz hesabına işlem yapıyoruz.
                Console.WriteLine("\nVadesiz Hesabı İşlemleri:");
                vadesizHesap.ParaYatir(1000);
                vadesizHesap.ParaCek(500);
                Console.WriteLine($"Vadesiz Hesap Bakiyesi: {vadesizHesap.Bakiye:C}");

                Console.ReadLine();
            }
            
        }
    }

}
