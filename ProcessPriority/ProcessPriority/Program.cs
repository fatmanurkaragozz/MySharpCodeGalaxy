using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            // GİRİŞ: Kullanıcıdan infix formatında bir matematiksel ifade alınır.
            Console.Write("Matematiksel ifade girin (ör. 3 + 4 * 2 / (1 - 5) ^ 2 ^ 3): ");
            string ifade = Console.ReadLine();

            // İnfix ifadeyi postfix formata çevir

            // Infix İfade: Operatörlerin operandlar arasında yer aldığı gösterim şeklidir. 
            // Günlük hayatta kullandığımız biçimdir. Örneğin, 3 + 5.

            // Postfix İfade: Operatörlerin operandlardan sonra geldiği gösterim şeklidir. 
            // Bilgisayarlar tarafından daha kolay işlenir ve parantez veya işlem önceliğine 
            // ihtiyaç duymaz. Örneğin, 3 5 +.

            string postfixIfade = InfixToPostfix(ifade);
            Console.WriteLine("Postfix İfade: " + postfixIfade); // ÇIKIŞ: Postfix ifadesini göster

            // Postfix ifadeyi değerlendir
            double sonuc = EvaluatePostfix(postfixIfade);
            Console.WriteLine("Sonuç: " + sonuc); // ÇIKIŞ: Sonucu göster

            Console.ReadLine();
        }

        // İnfix ifadeyi Postfix'e çevirme fonksiyonu
        static string InfixToPostfix(string ifade)
        {
            Stack<char> yigin = new Stack<char>(); // Operatörleri saklamak için yığın
            StringBuilder postfix = new StringBuilder(); // Postfix sonucunu biriktirmek için

            // GİRİŞ: Karakterler tek tek okunarak postfix dönüşüm işlemine başlanır
            foreach (char ch in ifade)
            {
                // KONTROL: Sayı ya da ondalık nokta mı?
                if (char.IsDigit(ch) || ch == '.')
                {
                    postfix.Append(ch); // MATEMATİK: Sayıyı postfix ifadesine ekle
                }
                else if (ch == '(') // KONTROL: Parantez açma ise
                {
                    yigin.Push(ch); // MATEMATİK: Parantez açma yığına eklenir
                }
                else if (ch == ')') // KONTROL: Parantez kapatma
                {
                    // TEKRAR: '(' operatörü bulunana kadar yığından çıkar ve postfix'e ekle
                    while (yigin.Peek() != '(')
                    {
                        postfix.Append(' ').Append(yigin.Pop()); // ÇIKIŞ: Operatörleri postfix'e ekle
                    }
                    yigin.Pop(); // KONTROL: '(' parantezini çıkar
                }
                else if (IsOperator(ch)) // KONTROL: Eğer operatörse (ör: +, -, *, /, ^)
                {
                    postfix.Append(' '); // ÇIKIŞ: Operatörler arasına boşluk ekle

                    // TEKRAR: Yığın boş değilse ve yığında bulunan operatör öncelikli ise
                    while (yigin.Count > 0 && Precedence(yigin.Peek()) >= Precedence(ch))
                    {
                        postfix.Append(yigin.Pop()).Append(' '); // ÇIKIŞ: Postfix'e ekle
                    }
                    yigin.Push(ch); // MATEMATİK: Mevcut operatörü yığına ekle
                }
            }

            // Yığındaki kalan operatörleri postfix ifadesine ekle
            while (yigin.Count > 0)
            {
                postfix.Append(' ').Append(yigin.Pop()); // ÇIKIŞ: Tüm operatörleri ekle
            }

            return postfix.ToString(); // ÇIKIŞ: Postfix ifadesi olarak döndür
        }

        // Postfix ifadeyi değerlendiren fonksiyon
        static double EvaluatePostfix(string postfix)
        {
            Stack<double> yigin = new Stack<double>(); // MATEMATİK: Hesaplama için yığın
            StringBuilder islemSuresi = new StringBuilder(); // ÇIKIŞ: İşlem sürecini sakla

            // GİRİŞ: Postfix ifadeyi boşluklara göre böl ve sırayla işle
            foreach (string token in postfix.Split(' '))
            {
                // KONTROL: Eğer sayıysa
                if (double.TryParse(token, out double sayi))
                {
                    yigin.Push(sayi); // MATEMATİK: Sayıyı yığına ekle
                }
                else if (IsOperator(token[0])) // KONTROL: Operatör ise
                {
                    // MATEMATİK: İki sayıyı yığından çıkar
                    double b = yigin.Pop();
                    double a = yigin.Pop();
                    double sonuc = Hesapla(a, b, token[0]); // İşlem sonucu hesapla

                    // ÇIKIŞ: İşlem sürecini göster
                    islemSuresi.AppendLine($"{a} {token[0]} {b} = {sonuc}");

                    yigin.Push(sonuc); // MATEMATİK: İşlem sonucunu tekrar yığına ekle
                }
            }

            // İşlem sürecini ekrana yazdır
            Console.WriteLine("İşlem Süreci:\n" + islemSuresi.ToString()); // ÇIKIŞ: Adım adım işlemleri göster

            return yigin.Pop(); // ÇIKIŞ: Yığındaki son sonucu döndür

        }

        // Dört işlem ve üs alma hesaplama fonksiyonu
        static double Hesapla(double a, double b, char operatör)
        {
            // KONTROL ve MATEMATİK: Operatöre göre işlem yapılır
            switch (operatör)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
                case '^': return Math.Pow(a, b); // Üs alma işlemi
                default: throw new ArgumentException("Geçersiz operatör: " + operatör); // HATA KONTROL
            }
        }

        // Operatör olup olmadığını kontrol eden fonksiyon
        static bool IsOperator(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '^'; // KONTROL: Tanımlı operatörler
        }

        // Operatör öncelik sırasını belirleyen fonksiyon
        static int Precedence(char operatör)
        {
            // MATEMATİK: Operatör önceliği
            switch (operatör)
            {
                case '+':
                case '-': return 1;
                case '*':
                case '/': return 2;
                case '^': return 3;
                default: return 0;
            }
        }
    }
}
