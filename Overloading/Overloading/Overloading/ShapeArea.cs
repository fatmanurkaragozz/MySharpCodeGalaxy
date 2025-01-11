using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Overloading.Overloading
{
    class ShapeArea
    {
        // İlk sürüm: Karenin alanını hesaplar (Bir kenar uzunluğu verilerek)
        public double Alan(int kenar)  // Parametre türünü int yaparak ayırdık
        {
            return kenar * kenar;  // Karenin alanı: kenar * kenar
        }

        // İkinci sürüm: Dikdörtgenin alanını hesaplar (İki kenar uzunluğu verilerek)
        public double Alan(double uzunluk, double genislik)  // Parametreleri çift olarak bıraktık
        {
            return uzunluk * genislik;  // Dikdörtgenin alanı: uzunluk * genişlik
        }

        // Üçüncü sürüm: Dairenin alanını hesaplar (Yarıçap verilerek)
        public double Alan(double yaricap)  // Parametre türünü float olarak değiştirdik
        {
            return Math.PI * yaricap * yaricap;  // Dairenin alanı: π * r^2
        }
    }

    class Program3
    {
        static void Main()
        {
            ShapeArea shapeArea = new ShapeArea();

            // İlk sürüm: Karenin alanını hesaplama
            double kareAlan = shapeArea.Alan(5);
            Console.WriteLine("Karenin alanı: " + kareAlan);  // Çıktı: 25

            // İkinci sürüm: Dikdörtgenin alanını hesaplama
            double dikdortgenAlan = shapeArea.Alan(4, 6);
            Console.WriteLine("Dikdörtgenin alanı: " + dikdortgenAlan);  // Çıktı: 24

            // Üçüncü sürüm: Dairenin alanını hesaplama
            double daireAlan = shapeArea.Alan(3.0);
            Console.WriteLine("Dairenin alanı: " + daireAlan);  // Çıktı: 28.2743338823081

            Console.ReadLine();
        }
    }
}
