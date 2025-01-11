using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class Destructors
    {
        int i; double k;
        public Destructors(int ii, double kk)
        {
            i = ii; k = kk; double j = (i) + (k);
            Console.WriteLine(j);

        }
        ~Destructors()
        {
            double j = i - k;
            Console.WriteLine(j);
        }

        
    }

     class CalistirDestructori
    {
        static void Main(string[] args)
        {
            Destructors s = new Destructors(9, 2.5);
            Console.ReadLine();
        }
    }
}
