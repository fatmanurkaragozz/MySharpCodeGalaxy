using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class Zaman
    {
        public int Saat;
        public int Dakika;
        public int Saniye;

        public Zaman(int saat, int dakika, int saniye)
        {
            Dakika = dakika + saniye / 60;
            Saniye = saniye % 60;
            Saat = saat + Dakika / 60;
            Dakika = Dakika % 60;
        }

        public static Zaman operator +(Zaman a, Zaman b)
        {
            int ToplamSaniye = a.Saniye + b.Saniye;
            int ToplamDakika = a.Dakika + b.Dakika;
            int ToplamSaat = a.Saat + b.Saat;
            return new Zaman(ToplamSaat, ToplamDakika, ToplamSaniye);
        }

        public static bool operator ==(Zaman a, Zaman b)
        {
            if (a.Saniye == b.Saniye && a.Dakika == b.Dakika && a.Saat == b.Saat)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator!=(Zaman a, Zaman b){
            return !(a==b);
        }

        // Explict operatörü: Zaman -> string
        // Zaman sınıfını bir strig'e açıkça dönüştürmek için kullanılır.
        public static explicit operator string(Zaman z)
        {
            return $"{z.Saat:D2}:{z.Dakika:D2}:{z.Saniye:D2}";
        }

        // Implicit operatörü: string -> Zaman
        // string türünden Zaman nesnesine dönüşümü otomatik olarak yapar.
        public static implicit operator Zaman(string zamanStr)
        {
            string[] parts = zamanStr.Split(':');
            int saat = int.Parse(parts[0]);
            int dakika = int.Parse(parts[1]);
            int saniye = int.Parse(parts[2]);
            return new Zaman(saat, dakika, saniye);
        }

        // Parse bir string'i tam sayı değerine dönüştürür.

        static void Main()
        {
            Zaman zaman1 = new Zaman(5, 59, 60);
            Zaman zaman2 = new Zaman(1, 0, 120);
            Zaman zaman3 = zaman1 + zaman2;

            Console.WriteLine("{0}.{1}.{2}", zaman3.Saat, zaman3.Dakika, zaman3.Saniye);

            // == operatörü ile karşılaştırma
            bool esitMi = zaman1 == zaman2;
            Console.WriteLine("Zaman1 ve Zaman2 eşit mi? {0}", esitMi);

            // != operatörü ile karşılaştırma
            bool farkliMi = zaman1 != zaman3;
            Console.WriteLine("Zaman1  ve Zaman3 farklı mı? {0}", farkliMi);

            // Explicit dönüşüm kullanımı (Zaman -> string)
            string zamanStr = (string)zaman1;
            Console.WriteLine("Zaman1 string formatında: {0}", zamanStr);

            // Implicit dönüşüm kullanımı (string -> Zaman)
            Zaman zaman4 = "12:45:34";
            Console.WriteLine("String'den oluşturulan Zaman4: {0}.{1}.{2}", zaman4.Saat, zaman4.Dakika, zaman4.Saniye);


            Console.ReadLine();
        }
    }
}
