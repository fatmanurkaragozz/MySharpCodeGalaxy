using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading.Enums
{
    // Trafik ışığı durumlarını temsil eden Enum
    public enum TrafficLightState
    {
        Red,    // Kırmızı ışık - Dur
        Yellow, // Sarı ışık - Hazırlan
        Green   // Yeşil ışık - Geç
    }

    public class TrafficLight
    {
        // Trafik ışığı durumuna göre eylemi döndüren metot
        public string GetAction(TrafficLightState state)
        {
            // Duruma göre kontrol yapılıyor
            switch (state)
            {
                case TrafficLightState.Red:
                    return "Dur!"; // Kırmızıda dur
                case TrafficLightState.Yellow:
                    return "Hazırlan!"; // Sarıda hazırlan
                case TrafficLightState.Green:
                    return "Geç!"; // Yeşilde geç
                default:
                    return "Geçersiz durum."; // Bilinmeyen durum
            }
        }
    }

    public class Program12
    {
        public static void Main(string[] args)
        {
            // Trafik ışığı nesnesi oluşturuluyor
            var trafficLight = new TrafficLight();

            // Farklı trafik ışığı durumları için eylemler yazdırılıyor
            Console.WriteLine("Red: " + trafficLight.GetAction(TrafficLightState.Red));    // Kırmızı ışık testi
            Console.WriteLine("Yellow: " + trafficLight.GetAction(TrafficLightState.Yellow)); // Sarı ışık testi
            Console.WriteLine("Green: " + trafficLight.GetAction(TrafficLightState.Green));   // Yeşil ışık testi

            // Kullanıcı dostu bir çıkış mesajı
            Console.WriteLine("Trafik ışığı simülasyonu tamamlandı.");
        }
    }
}

