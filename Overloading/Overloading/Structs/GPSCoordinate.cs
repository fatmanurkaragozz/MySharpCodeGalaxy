using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading.Structs
{
    using System;

    namespace GPSDistanceCalculator
    {
        public struct GPSCoordinate
        {
            // Enlem (Latitude) ve Boylam (Longitude) özellikleri
            public double Latitude { get; private set; }
            public double Longitude { get; private set; }

            // Yapıcı metod (Constructor) - Enlem ve Boylam atanıyor
            public GPSCoordinate(double latitude, double longitude)
            {
                // Geçerli koordinat aralıkları kontrol ediliyor
                if (latitude < -90 || latitude > 90)
                    throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude must be between -90 and 90 degrees.");

                if (longitude < -180 || longitude > 180)
                    throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude must be between -180 and 180 degrees.");

                Latitude = latitude;
                Longitude = longitude;
            }

            // İki GPS konumu arasındaki mesafeyi kilometre cinsinden hesaplayan metot
            public double DistanceTo(GPSCoordinate other)
            {
                // Yarıçap değeri (Dünya yarıçapı kilometre cinsinden)
                const double EarthRadiusKm = 6371.0;

                // Dereceleri radyan cinsine çeviriyoruz
                double lat1Rad = DegreesToRadians(Latitude);
                double lon1Rad = DegreesToRadians(Longitude);
                double lat2Rad = DegreesToRadians(other.Latitude);
                double lon2Rad = DegreesToRadians(other.Longitude);

                // Haversine formülü
                double deltaLat = lat2Rad - lat1Rad;
                double deltaLon = lon2Rad - lon1Rad;

                double a = Math.Pow(Math.Sin(deltaLat / 2), 2) +
                           Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                           Math.Pow(Math.Sin(deltaLon / 2), 2);

                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                // Mesafe hesaplama
                double distance = EarthRadiusKm * c;
                return distance;
            }

            // Dereceleri radyana çeviren yardımcı metot
            private static double DegreesToRadians(double degrees)
            {
                return degrees * (Math.PI / 180.0);
            }

            // ToString metodu - Konumun okunabilir formatta yazdırılması
            public override string ToString()
            {
                return $"Latitude: {Latitude}, Longitude: {Longitude}";
            }
        }

        public class Program11
        {
            public static void Main(string[] args)
            {
                // İki GPS konumu oluşturuluyor
                var konum1 = new GPSCoordinate(36.9021, 30.7123); // Antalya, Türkiye
                var konum2 = new GPSCoordinate(41.0082, 28.9784); // İstanbul, Türkiye

                // Mesafe hesaplama
                double mesafe = konum1.DistanceTo(konum2);

                // Sonuçların yazdırılması
                Console.WriteLine($"Konum 1: {konum1}");
                Console.WriteLine($"Konum 2: {konum2}");
                Console.WriteLine($"İki konum arasındaki mesafe: {mesafe:F2} km");

                Console.ReadLine();
            }
        }
    }

}
