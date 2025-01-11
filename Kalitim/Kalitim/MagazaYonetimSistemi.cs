using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalitim
{
    // Soyut ürün sınıfı, temel özellikleri ve ödeme hesaplama metodunu tanımlar.
    public abstract class Urun
    {
        // Ürün adı ve fiyatını tutan özellikler
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        // Soyut metod, türetilen sınıflarda ödeme hesaplaması için override edilecek.
        // Her türetilen sınıf kendi ödeme hesaplama mantığını bu metod ile belirler.
        public abstract decimal HesaplaOdeme();

        // Ürün bilgilerini yazdırma metodu
        // Bu metod, temel özelliklerin yazdırılması için kullanılır.
        public virtual void BilgiYazdir()
        {
            // Ürün adı ve fiyatı yazdırılır. Fiyat, para birimi formatında yazdırılır.
            Console.WriteLine($"Ürün Adı: {Ad}, Fiyat: {Fiyat:C}");
        }
    }

    // Kitap sınıfı, Urun sınıfından türetilmiştir ve kitap türündeki ürünlere özgü vergi hesaplaması yapar.
    public class Kitap : Urun
    {
        // Kitap için yazar bilgisi
        public string Yazar { get; set; }

        // Kitap için ödeme hesaplaması metodunu override ederiz.
        // Bu metot, kitapların üzerine %10 vergi ekler.
        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * 0.10m); // %10 vergi eklenir.
        }

        // Kitap bilgilerini yazdırma metodu.
        // Ürün bilgilerini yazdırdıktan sonra, kitapla ilgili ekstra bilgileri de ekrana basar.
        public override void BilgiYazdir()
        {
            // Temel ürün bilgilerini yazdır.
            base.BilgiYazdir();
            // Kitabın yazarı ve ödenecek toplam tutarı yazdır.
            Console.WriteLine($"Yazar: {Yazar}, Ödenecek Tutar: {HesaplaOdeme():C}");
        }
    }

    // Elektronik sınıfı, Urun sınıfından türetilmiştir ve elektronik ürünlere özgü vergi hesaplaması yapar.
    public class Elektronik : Urun
    {
        // Elektronik ürünün markası
        public string Marka { get; set; }

        // Elektronik ürünler için ödeme hesaplaması metodunu override ederiz.
        // Elektronik ürünler üzerine %25 vergi eklenir.
        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * 0.25m); // %25 vergi eklenir.
        }

        // Elektronik ürün bilgilerini yazdırma metodu.
        // Ürün bilgilerini yazdırdıktan sonra, elektronik ürünle ilgili ekstra bilgileri ekrana basar.
        public override void BilgiYazdir()
        {
            // Temel ürün bilgilerini yazdır.
            base.BilgiYazdir();
            // Elektroniğin markası ve ödenecek toplam tutarı yazdır.
            Console.WriteLine($"Marka: {Marka}, Ödenecek Tutar: {HesaplaOdeme():C}");
        }
    }

    // Program sınıfı, uygulamanın çalışmasını test eder.
    public class Program6
    {
        public static void Main(string[] args)
        {
            // Farklı türde ürünler içeren bir liste oluşturuyoruz.
            // Bu liste, Urun sınıfından türetilmiş olan Kitap ve Elektronik sınıfını içeriyor.
            List<Urun> urunler = new List<Urun>
            {
                new Kitap { Ad = "C# Programlama", Fiyat = 100, Yazar = "Ahmet Yılmaz" },
                new Elektronik { Ad = "Akıllı Telefon", Fiyat = 5000, Marka = "TechPro" }
            };

            // Ürünleri listeleyip ödeme hesaplamalarını ekrana yazdırıyoruz.
            foreach (var urun in urunler)
            {
                // Her bir ürün için bilgilerini yazdır.
                urun.BilgiYazdir();
                // Ürünler arasında ayırıcı çizgi ekle.
                Console.WriteLine("---------------------------------");
            }

            Console.ReadLine();
        }
    }
}
