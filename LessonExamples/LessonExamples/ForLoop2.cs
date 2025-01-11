using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class ForLoop2
    {
        static void Main()
        {
            string s;

            for(s = Console.ReadLine(); s != "Çıkış"; s = Console.ReadLine())
            {
                Console.WriteLine(s);
            }
        }
    }
}
