using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class TheBiggestMethod
    {
        static void Main()
        {
            Console.WriteLine("3 tane sayı giriniz: ");
            int s1 = Convert.ToInt32(Console.ReadLine());
            int s2 = Convert.ToInt32(Console.ReadLine());
            int s3 = Convert.ToInt32(Console.ReadLine());

            int enbuyuk = EnBuyuk3(s1, s2, s3);
            Console.WriteLine("En büyük: {0}\'dir.", enbuyuk);

            Console.ReadLine();

        }

        static int EnBuyuk(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static int EnBuyuk3(int a, int b, int c)
        {
            return EnBuyuk(a, EnBuyuk(b, c));
        }

        
    }
}
