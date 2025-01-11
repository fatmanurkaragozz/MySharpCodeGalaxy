using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class Arrays2
    {
        static void Main()
        {
            Random r = new Random();

            int[] dizi = new int[20];
            char[] chr = new char[20];

            for(int i = 0; i < 20; i++)
            {
                dizi[i] = r.Next(1, 100);
                chr[i] = (char)r.Next(20, 126);
            }

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("{0,2}. deger {1, 2} ->", i, dizi[i]);

                for (int j = 0; j < dizi[i]; j++) // Ekrana kaç kere chr karekterinin yazılacağını belirler
                {
                    Console.Write(chr[i]);
                   
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
