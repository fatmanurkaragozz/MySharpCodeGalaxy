using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading.Indexers
{
    // Çok Katmanlı Otopark Sınıfı
    class ParkingLot
    {
        // 3 katlı ve her katta 5 park yeri olan bir otopark dizisi (kat x park yeri)
        private string[,] parkingSpaces = new string[3, 5];

        // Kurucu metot: Tüm park yerlerini başlangıçta "Empty" olarak ayarla
        public ParkingLot()
        {
            for (int floor = 0; floor < 3; floor++)
            {
                for (int spot = 0; spot < 5; spot++)
                {
                    parkingSpaces[floor, spot] = "Empty"; // Tüm park yerlerini boş yapıyoruz
                }
            }
        }

        // Çift boyutlu indeksleyici: Kat ve park yeri bilgilerine erişim sağlar
        public string this[int floor, int spot]
        {
            get
            {
                // Geçerli kat ve park yeri kontrolü
                if (floor < 0 || floor >= 3 || spot < 0 || spot >= 5)
                {
                    return "Error: Invalid parking spot!";
                }
                // Belirtilen park yerindeki aracın plakasını döndürür (boşsa Empty)
                return parkingSpaces[floor, spot];
            }
            set
            {
                // Geçerli kat ve park yeri kontrolü
                if (floor < 0 || floor >= 3 || spot < 0 || spot >= 5)
                {
                    Console.WriteLine("Error: Invalid parking spot!");
                }
                // Eğer park yeri boşsa araç plakası eklenir
                else if (parkingSpaces[floor, spot] == "Empty")
                {
                    parkingSpaces[floor, spot] = value;
                    Console.WriteLine($"Vehicle with plate '{value}' parked at floor {floor}, spot {spot}.");
                }
                // Eğer park yeri doluysa hata mesajı döner
                else
                {
                    Console.WriteLine($"Error: Spot {spot} on floor {floor} is already occupied.");
                }
            }
        }

        // Otoparktaki mevcut durumu yazdıran metot
        public void PrintParkingLot()
        {
            Console.WriteLine("\nCurrent Parking Lot Status:");
            for (int floor = 0; floor < 3; floor++)
            {
                Console.WriteLine($"Floor {floor + 1}:");
                for (int spot = 0; spot < 5; spot++)
                {
                    Console.Write($"{parkingSpaces[floor, spot].PadRight(10)}");
                }
                Console.WriteLine("\n");
            }
        }
    }

    class Program8
    {
        static void Main(string[] args)
        {
            // Otopark nesnesini oluştur
            ParkingLot parkingLot = new ParkingLot();

            // Başlangıç durumu yazdır
            parkingLot.PrintParkingLot();

            // Araçları park etme denemeleri
            parkingLot[0, 0] = "34ABC123";
            parkingLot[0, 1] = "06XYZ456";
            parkingLot[1, 2] = "35LMN789";

            // Dolu bir park yerine araç eklemeye çalışalım
            parkingLot[0, 0] = "55DEF987"; // Hata vermeli çünkü dolu

            // Geçersiz park yeri denemesi
            parkingLot[3, 0] = "44GHI321"; // Geçersiz kat, hata verir

            // Park yerlerindeki mevcut durumu göster
            parkingLot.PrintParkingLot();

            // Bir park yerindeki aracın plakasını gösterme
            Console.WriteLine($"Plate in floor 1, spot 1: {parkingLot[0, 0]}");

            Console.ReadLine();
        }
    }
}
