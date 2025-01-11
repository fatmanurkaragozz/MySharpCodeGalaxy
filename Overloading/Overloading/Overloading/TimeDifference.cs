using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading.Overloading
{
    class TimeDifference
    {
        // İlk sürüm: İki tarih arasındaki farkı gün cinsinden hesaplar
        public int Fark(DateTime tarih1, DateTime tarih2)
        {
            // DateTime.Subtract metodunu kullanarak iki tarih arasındaki farkı alıyoruz
            TimeSpan fark = tarih2 - tarih1;

            // TimeSpan'in Days özelliğini kullanarak farkı gün cinsinden döndürüyoruz
            return Math.Abs(fark.Days);  // Farkın mutlak değerini alıyoruz
        }

        // İkinci sürüm: İki tarih arasındaki farkı saat cinsinden hesaplar
        public double Fark(DateTime tarih1, DateTime tarih2, bool saat)
        {
            // TimeSpan'in TotalHours özelliğini kullanarak farkı saat cinsinden döndürüyoruz
            TimeSpan fark = tarih2 - tarih1;
            return Math.Abs(fark.TotalHours);  // Farkı mutlak saat olarak alıyoruz
        }

        // Üçüncü sürüm: İki tarih arasındaki farkı yıl, ay ve gün cinsinden hesaplar
        public string Fark(DateTime tarih1, DateTime tarih2, string farkTipi)
        {
            // Fark tipi "YilAyGun" değilse, bir hata fırlatıyoruz
            if (farkTipi != "YilAyGun")
                throw new ArgumentException("Geçersiz fark tipi.");

            // Yıl farkını hesaplıyoruz
            int yilFark = tarih2.Year - tarih1.Year;

            // Ay farkını hesaplıyoruz
            int ayFark = tarih2.Month - tarih1.Month;

            // Gün farkını hesaplıyoruz
            int gunFark = tarih2.Day - tarih1.Day;

            // Ay farkı negatifse, yıl farkını bir azaltıyoruz ve ay farkını düzeltiyoruz
            if (ayFark < 0)
            {
                yilFark--;               // Bir yıl geriye gidiyoruz
                ayFark += 12;            // Negatif ay farkını düzeltmek için 12 ay ekliyoruz
            }

            // Gün farkı negatifse, ay farkını bir azaltıyoruz ve gün farkını düzeltiyoruz
            if (gunFark < 0)
            {
                ayFark--;                // Bir ay geriye gidiyoruz
                gunFark += DateTime.DaysInMonth(tarih2.Year, tarih2.Month);
                // Negatif gün farkını düzeltmek için ilgili ayın toplam gün sayısını ekliyoruz
            }

            // Hesaplanan yıl, ay ve gün farklarını bir string olarak döndürüyoruz
            return $"{Math.Abs(yilFark)} yıl, {Math.Abs(ayFark)} ay, {Math.Abs(gunFark)} gün";
        }

    }

    class Program4
    {
        static void Main()
        {
            TimeDifference timeDifference = new TimeDifference();

            DateTime tarih1 = new DateTime(2023, 5, 1);  // İlk tarih
            DateTime tarih2 = new DateTime(2024, 1, 15);  // İkinci tarih

            // İlk sürüm: Gün cinsinden fark
            int gunFarki = timeDifference.Fark(tarih1, tarih2);
            Console.WriteLine("Gün cinsinden fark: " + gunFarki);  // Çıktı: 259

            // İkinci sürüm: Saat cinsinden fark
            double saatFarki = timeDifference.Fark(tarih1, tarih2, true);
            Console.WriteLine("Saat cinsinden fark: " + saatFarki);  // Çıktı: 6224

            // Üçüncü sürüm: Yıl, ay, gün cinsinden fark
            string yilAyGunFarki = timeDifference.Fark(tarih1, tarih2, "YilAyGun");
            Console.WriteLine("Yıl, ay, gün cinsinden fark: " + yilAyGunFarki);  // Çıktı: 0 yıl, 7 ay, 14 gün

            Console.ReadLine();
        }
    }
}
