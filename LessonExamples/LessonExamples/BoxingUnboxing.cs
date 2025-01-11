using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class BoxingUnboxing
    {
        static void Main(string[] args)
        {
            Box(args);
        }

        static void Box(String[] args)
        {
            // unboxing işlemi doğrudan başka br türe yapılamaz. C#'ta, unboxing yalnızca
            // kutulanan (boxed) değer tipinin orjinal türüne dönüştürülmesiyle mümkündür

            int i = 10;
            object o = i; // Boxing
                          // int i değeri, object türüne atanarak heap’te bir kutu(boxing) işlemi gerçekleşir.

            // Önce int'e unbox, sonra long'a dönüştür
            // Kutudaki değer önce kendi orijinal türü olan int'e çıkarılır (unbox edilir).
            // Ardından, int değeri long türüne genişletme dönüşümü (implicit conversion) ile aktarılır.

            int temp = (int)o;
            long l = temp;

            Console.WriteLine(i);
            Console.WriteLine(l);
            Console.ReadLine();

            // long l = (long)(int)o;  // Unboxing ve dönüştürme : Böyle tek satırda da yapılabilir
        }

        
    }
}
