using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class IfStructure
    {
        public static void Main()
        {
            string s;
            int a, b, c;

            Console.Write("1.sayıyı giriniz : ");
            s = Console.ReadLine();
            a = Int32.Parse(s);
            Console.Write("2.sayıyı giriniz : ");
            s = Console.ReadLine();
            b = Int32.Parse(s);
            Console.Write("3. sayıyı giriniz : ");
            s = Console.ReadLine();
            c = Int32.Parse(s);

            if (a >= b && a >= c) Console.WriteLine("Enbüyük : " + a);
            else if (b >= c) Console.WriteLine("Enbüyük : " + b);
            else Console.WriteLine("Enbüyük : " + c);
            Console.ReadLine();
        }
    }
}
