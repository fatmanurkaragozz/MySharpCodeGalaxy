using System;

namespace TimeTraveler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Giriş: Şu anki tarih bilgisini alıyoruz.
            DateTime today = DateTime.Now;
            int startYear = 2000; // Zaman yolculuğuna uygun başlangıç yılı
            int endYear = 3000;   // Zaman yolculuğuna uygun bitiş yılı

            // Çıkış: Programın cihazın kabul ettiği uygun tarihleri listelemeye başladığını bildiriyoruz.
            Console.WriteLine("Cihazın kabul ettiği uygun tarihler:");

            // Tekrar: Belirlenen tarih aralığındaki tüm yıllar için bir döngü başlatıyoruz.
            for (int year = today.Year; year <= endYear; year++)
            {
                // Kontrol: Yılın cihaz tarafından kabul edilen koşullara uygun olup olmadığını kontrol ediyoruz.
                if (KucukMu(year)) // "KucukMu" metodu ile yılın dörtte bir koşulunu kontrol ediyoruz
                {
                    // Tekrar: Yıl koşulunu sağlayan her yıl için 12 ay boyunca döngü başlatıyoruz.
                    for (int month = 1; month <= 12; month++)
                    {
                        // Kontrol: Ayın cihaz tarafından kabul edilen koşullara uygun olup olmadığını kontrol ediyoruz.
                        if (CiftMi(month)) // "CiftMi" metodu ile ayın basamakları toplamının çift olup olmadığını kontrol ediyoruz
                        {
                            // Ayın toplam gün sayısını belirliyoruz (şubat, nisan vb. farklı olabilir)
                            int daysInMonth = DateTime.DaysInMonth(year, month);

                            // Tekrar: Günlerin her biri için uygunluğu kontrol eden bir döngü başlatıyoruz.
                            for (int day = 1; day <= daysInMonth; day++)
                            {
                                // Kontrol: Günün asal sayı olup olmadığını kontrol ediyoruz.
                                if (AsalMi(day)) // "AsalMi" metodu ile günün asal sayı olup olmadığını kontrol ediyoruz
                                {
                                    // Çıkış: Tüm koşulları sağlayan tarihler listeleniyor.
                                    DateTime validDate = new DateTime(year, month, day);
                                    Console.WriteLine(validDate.ToString("dd.MM.yyyy"));
                                }
                            }
                        }
                    }
                }
            }

            // Çıkış: Program tüm uygun tarihleri listelemeyi tamamladığını bildiriyor.
            Console.WriteLine("Tüm geçerli tarihler listelendi.");

            // Programın kapanmaması için kullanıcıdan bir giriş bekliyoruz.
            Console.ReadLine();
        }

        // Matematik: Sayının asal olup olmadığını kontrol eden metot
        static bool AsalMi(int number)
        {
            // 1 ve daha küçük sayılar asal olmadığı için kontrol ediliyor
            if (number <= 1) return false;
            if (number == 2) return true; // 2 en küçük asal sayı

            // Sayının kareköküne kadar olan sayılarla bölünebilirlik kontrolü yapılıyor
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false; // Eğer sayı kendisi dışında bir sayıya bölünüyorsa asal değil
            }
            return true; // Sayı asal
        }

        // Matematik: Ayın basamaklarının toplamının çift olup olmadığını kontrol eden metot
        static bool CiftMi(int number)
        {
            int toplam = 0; // Toplam değeri başlangıçta sıfır olarak tanımlanıyor

            // Tekrar: Sayının basamaklarını topluyoruz
            while (number != 0)
            {
                toplam += number % 10; // Sayının son basamağını toplama ekliyoruz
                number /= 10; // Bir sonraki basamağa geçiyoruz
            }

            // Çift olup olmadığını kontrol ediyoruz
            return toplam % 2 == 0;
        }

        // Matematik: Yılın basamakları toplamının yılın dörtte birinden küçük olup olmadığını kontrol eden metot
        static bool KucukMu(int number)
        {
            int toplam2 = 0;         // Basamaklar toplamını tutacak değişken
            int orijinalSayi = number; // Orijinal yıl sayısı saklanıyor

            // Tekrar: Yıl sayısının basamaklarını topluyoruz
            while (number > 0)
            {
                toplam2 += number % 10; // Son basamağı toplama ekliyoruz
                number /= 10;           // Bir sonraki basamağa geçiyoruz
            }

            // Çıkış: Basamaklar toplamı, yılın dörtte birinden küçükse true döner, değilse false
            return toplam2 < (orijinalSayi / 4);
        }
    }
}
