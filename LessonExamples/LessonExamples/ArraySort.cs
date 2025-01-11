using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class ArraySort
    {
        static void Main()
        {
            Array Dizi = Array.CreateInstance(typeof(string), 3);
            Dizi.SetValue("Ali", 0);
            Dizi.SetValue("Veli", 1);
            Dizi.SetValue("Sami", 2);

            Array.Sort(Dizi);

            foreach(string s in Dizi)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("-------------------------------------");

            string[] dizi2 = { "Zeynep", "Fatma", "Ali", "Yılmaz", "Gökhan", "Osman", "Feride" };

            Console.WriteLine("Dizinin Elemanları\n====================");

            foreach( string s in dizi2)
            {
                Console.WriteLine(s);
            }

            Array.Sort(dizi2);
            Console.WriteLine();

            Console.WriteLine("Sıralanmış Dizi\n===================");

            foreach(string s in dizi2)
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }
    }
}
