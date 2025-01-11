using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading.Structs
{
    // Karmaşık Sayıları temsil eden struct'ı tanımlıyoruz
    public struct ComplexNumber
    {
        // Gerçek kısmı (Real) ve sanal kısmı (Imaginary) temsil eden özellikler
        public double Real { get; private set; }
        public double Imaginary { get; private set; }

        // Yapıcı metot (Constructor): Gerçek ve sanal kısmı alır ve geçerli değerler atar.
        public ComplexNumber(double real, double imaginary)
        {
            Real = real;           // Gerçek kısmı atıyoruz
            Imaginary = imaginary; // Sanal kısmı atıyoruz
        }

        // Toplama işlemi yapan metot. İki karmaşık sayıyı toplar.
        public ComplexNumber Topla(ComplexNumber diger)
        {
            // Gerçek kısımlarını toplar, sanal kısımlarını toplar ve yeni karmaşık sayıyı döndürür.
            return new ComplexNumber(this.Real + diger.Real, this.Imaginary + diger.Imaginary);
        }

        // Çıkarma işlemi yapan metot. İki karmaşık sayıyı çıkarır.
        public ComplexNumber Cikarma(ComplexNumber diger)
        {
            // Gerçek kısımlarını çıkarır, sanal kısımlarını çıkarır ve yeni karmaşık sayıyı döndürür.
            return new ComplexNumber(this.Real - diger.Real, this.Imaginary - diger.Imaginary);
        }

        // Karmaşık sayıyı (a + bi) formatında döndüren ToString() metodu.
        public override string ToString()
        {
            // Eğer sanal kısım pozitifse, "a + bi" formatında; negatifse "a - bi" formatında yazdırır.
            if (Imaginary >= 0)
            {
                return $"{Real} + {Imaginary}i"; // Pozitif sanal kısmı "a + bi" formatında gösterir.
            }
            else
            {
                return $"{Real} - {Math.Abs(Imaginary)}i"; // Negatif sanal kısmı "a - bi" formatında gösterir.
            }
        }
    }
}
