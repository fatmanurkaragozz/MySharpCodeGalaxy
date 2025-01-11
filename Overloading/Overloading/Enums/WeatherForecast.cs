using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading.Enums
{
    // Hava durumu tiplerini temsil eden enum
    public enum WeatherType
    {
        Sunny,   // Güneşli
        Rainy,   // Yağmurlu
        Cloudy,  // Bulutlu
        Stormy   // Fırtınalı
    }

    public class WeatherAdvisor
    {
        // Hava durumu tipine göre tavsiye veren metot
        public string GetAdvice(WeatherType weather)
        {
            // Duruma göre öneri döndüren switch bloğu
            switch (weather)
            {
                case WeatherType.Sunny:
                    return "Hava güneşli, dışarı çıkmak için harika bir gün!";
                case WeatherType.Rainy:
                    return "Yağmurlu, yanınıza bir şemsiye alın!";
                case WeatherType.Cloudy:
                    return "Bulutlu, serin bir gün olabilir.";
                case WeatherType.Stormy:
                    return "Fırtınalı, mümkünse dışarı çıkmayın!";
                default:
                    return "Geçersiz hava durumu.";
            }
        }
    }

    public class Program13
    {
        public static void Main(string[] args)
        {
            // Hava durumu danışman nesnesi oluşturuluyor
            var weatherAdvisor = new WeatherAdvisor();

            // Farklı hava durumları için tavsiyeler yazdırılıyor
            Console.WriteLine("Sunny: " + weatherAdvisor.GetAdvice(WeatherType.Sunny));
            Console.WriteLine("Rainy: " + weatherAdvisor.GetAdvice(WeatherType.Rainy));
            Console.WriteLine("Cloudy: " + weatherAdvisor.GetAdvice(WeatherType.Cloudy));
            Console.WriteLine("Stormy: " + weatherAdvisor.GetAdvice(WeatherType.Stormy));

            // Kullanıcıya simülasyon tamamlandı bilgisi
            Console.WriteLine("Hava durumu tahminleri tamamlandı.");
            Console.ReadLine();
        }
    }
}
