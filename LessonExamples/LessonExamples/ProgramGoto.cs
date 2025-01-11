using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class ProgramGoto
    {
        public static void Main()
        {
            int m = 0;
            int n = 10;

        bas: // "bas" etiketi, kodda bir konumu belirtir. "goto bas;" ile bu etikete dönülebilir
            m++; // m değişkeni her döngüde 1 artırılır

            // m değişkeninin n (10) değerine ulaşana kadar kendini döngüsel olarak artırması sağlanır
            if (m <= n) goto bas;
            else goto son;

        son: // "son" etiketi, işlemin sonunda m'nin değerinin yazdırılacağı yerdir
            Console.WriteLine("m = " + m); // m değeri 11 olduğu için ekrana "m = 11" yazdırılır

            Console.ReadLine();
        }
    }
}
