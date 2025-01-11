using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class ForLoop1
    {
        public static void Main(string[] args)
        {
            for(int i = 0, j = 0; i < 20; i++, j++)
            {
                i *= j;
                Console.WriteLine("i = " + i + " j = " + j);
            }

            Console.ReadLine();
        }
    }
}
