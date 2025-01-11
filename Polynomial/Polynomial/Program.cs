using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PolinomCalculator
{
    // Polynomial sınıfı her bir polinomu ve polinom işlemlerini temsil eder.
    class Polynomial
    {
        // Terimler adlı sözlük, her derecenin katsayısını tutar. Örneğin, 2x^2 ifadesinde 2 katsayısı ve 2 derecesi bulunur.
        public Dictionary<int, double> Terimler { get; set; } = new Dictionary<int, double>();

        // Yapıcı metod, kullanıcı tarafından girilen polinom ifadesini alır ve bunu ayrıştırır.
        public Polynomial(string polinom)
        {
            ParsePolinom(polinom); // Polinom ifadesini parçalayarak her terimi sözlüğe kaydeder.
        }

        // ParsePolinom metodu, polinom ifadesini terimlerine ayırır ve her terimi derecesine göre sözlükte saklar.
        private void ParsePolinom(string polinom)
        {
            // Regex ifadesi, polinomun her terimini (örneğin 2x^2 veya -3x) eşleştirir.
            var matches = Regex.Matches(polinom, @"([+-]?\s*\d*)(x(\^\d+)?)?");
            foreach (Match match in matches)
            {
                // Eğer match boş bir terimse (örneğin yalnızca + veya - gibi), döngünün bu adımını atla.
                if (match.Value.Trim() == "") continue;

                // Katsayı belirlenir; eğer boş veya "+" işareti varsa katsayı 1 kabul edilir, "-" varsa -1 kabul edilir.
                double katsayi = match.Groups[1].Value.Trim() == "" || match.Groups[1].Value.Trim() == "+" ? 1 : match.Groups[1].Value.Trim() == "-" ? -1 : double.Parse(match.Groups[1].Value);

                // Derece belirlenir; eğer belirtilmemişse (örneğin "x" olarak), derece 1 kabul edilir. Yoksa 0 derecesi (sabit sayı) atanır.
                int derece = match.Groups[3].Success ? int.Parse(match.Groups[3].Value.Substring(1)) : match.Groups[2].Success ? 1 : 0;

                // Eğer aynı dereceden terim varsa katsayılar toplanır, yoksa yeni bir derece-katsayı çifti eklenir.
                if (Terimler.ContainsKey(derece))
                    Terimler[derece] += katsayi;
                else
                    Terimler[derece] = katsayi;
            }
        }

        // İki polinomu toplamak için "+" operatörü aşırı yüklenmiştir.
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            var result = new Polynomial(""); // Boş bir sonuç polinomu başlatır.
            foreach (var term in p1.Terimler)
                result.Terimler[term.Key] = term.Value;  // Birinci polinomun tüm terimlerini sonuç polinomuna ekler.


            foreach (var term in p2.Terimler)
            {
                // Eğer aynı dereceden terim varsa katsayılar toplanır, yoksa yeni derece eklenir.
                if (result.Terimler.ContainsKey(term.Key))
                    result.Terimler[term.Key] += term.Value;
                else
                    result.Terimler[term.Key] = term.Value;
            }
            return result; // Toplama sonucu döndürülür.
        }

        // İki polinomu çıkarmak için "-" operatörü aşırı yüklenmiştir.
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            var result = new Polynomial(""); // Boş bir sonuç polinomu başlatır.
            foreach (var term in p1.Terimler)
                result.Terimler[term.Key] = term.Value; // Birinci polinomun tüm terimlerini sonuç polinomuna ekler.

            foreach (var term in p2.Terimler)
            {
                // Aynı dereceden terim varsa katsayılar çıkarılır, yoksa ters işaretli olarak yeni derece eklenir.
                if (result.Terimler.ContainsKey(term.Key))
                    result.Terimler[term.Key] -= term.Value;
                else
                    result.Terimler[term.Key] = -term.Value;
            }
            return result; // Çıkarma sonucu döndürülür.
        }

        // Polinomu string formatında yazdırmak için ToString metodu.
        public override string ToString()
        {
            var terms = new List<string>(); // Tüm terimleri string listesine eklemek için bir liste oluşturur.
            foreach (var term in Terimler)
            {
                // Eğer katsayı sıfırsa terim gösterilmez.
                if (term.Value == 0) continue;

                // Katsayı ve dereceye göre terim string formatında düzenlenir.
                string coeff = term.Value == 1 && term.Key != 0 ? "" : term.Value == -1 && term.Key != 0 ? "-" : term.Value.ToString();
                string power = term.Key == 0 ? "" : term.Key == 1 ? "x" : $"x^{term.Key}";

                // Her terim listesine eklenir.
                terms.Add($"{coeff}{power}");
            }
            // Polinom terimleri birleştirilir ve pozitif terimlerden önce + işareti eklenmez.
            return string.Join(" + ", terms).Replace("+ -", "- ");
        }
    }

    class Program
    {
        static void Main()
        {
            // Program kullanıcının çıkış yapmak isteyip istemediğini kontrol eder ve işlem yapmaya devam eder.
            while (true)
            {
                Console.WriteLine("Polinomları girin veya çıkmak için 'exit' yazın.");

                // Kullanıcıdan ilk polinom girişi alınır.
                Console.Write("Birinci polinom: ");
                string polinom1Input = Console.ReadLine();
                if (polinom1Input.ToLower() == "exit") break; // Kullanıcı 'exit' yazarsa döngü sonlanır.
                Polynomial polinom1 = new Polynomial(polinom1Input); // İlk polinom nesnesi oluşturulur.

                // Kullanıcıdan ikinci polinom girişi alınır.
                Console.Write("İkinci polinom: ");
                string polinom2Input = Console.ReadLine();
                if (polinom2Input.ToLower() == "exit") break; // Kullanıcı 'exit' yazarsa döngü sonlanır.
                Polynomial polinom2 = new Polynomial(polinom2Input); // İkinci polinom nesnesi oluşturulur.

                // Toplama ve çıkarma işlemleri yapılır.
                Polynomial toplam = polinom1 + polinom2; // İki polinomun toplamı
                Polynomial fark = polinom1 - polinom2;   // İki polinomun farkı

                // Toplama ve çıkarma sonuçları ekrana yazdırılır.
                Console.WriteLine("Toplam: " + toplam);
                Console.WriteLine("Fark: " + fark);
                Console.WriteLine(); // Ekran çıkışları arasında boşluk bırakılır.
            }
        }
    }
}
