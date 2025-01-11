using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class Method4
    {
        static int DegerTipAktarim(int sayi)
        {
            sayi = 30;
            return sayi;
        }

        static void Main()
        {
            int x = 100;
            Console.WriteLine(x);

            DegerTipAktarim(x);
            Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}

// #'da değer tipleri (örneğin int, float, double, vb.) bir metot çağrılırken kopyalanır.
// Yani, DegerTipAktarim(x) çağrıldığında, x değişkeninin kendisi değil, yalnızca değeri(100) metot parametresine aktarılır.
// Bu nedenle, metodun içinde sayi değişkeni güncellense bile bu değişiklik, Main metodundaki x değişkenini etkilemez.
// Eğer değişiklik x üzerinde etkili olsun istiyorsak;
// 1- ref kullanabiliriz böylece bir değişkeni referansla (asıl adresiyle) metoda gönderebiliriz.
// 2- Metodun geri dönüş değerini kullanarak değişikliği x' e atayabiliriz.
// Değer Tipleri (Value Types): Metoda kopyaları gönderilir, asıl değer değişmez.
// Referans Tipleri (Reference Types): Referans gönderilir, asıl değer değişebilir.
