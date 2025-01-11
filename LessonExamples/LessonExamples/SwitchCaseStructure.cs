using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class SwitchCaseStructure
    {
        public static void Main()
        {
            int a;

            Console.Write("Kaçıncı Sınıftasınız : ");
            a = Convert.ToInt32(Console.ReadLine());

            switch (a)
            {
                case (1): Console.WriteLine("Daha Yenisiniz");
                    break;
                case (2): Console.WriteLine("Mirasçısınız");
                    break;
                case (3): Console.WriteLine("Ev Sahibisiniz");
                    break;
                case (4): Console.WriteLine("Misafirsiniz");
                    break;
                default: Console.WriteLine("Siz okulu uzatmışsınız"); goto case 1;
            }

            Console.ReadLine();
        }
    }
}
