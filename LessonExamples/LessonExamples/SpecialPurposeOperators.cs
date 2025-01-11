using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class SpecialPurposeOperators
    {
        public static void Main()
        {
            Type t;
            int i = 123;
            float f = 23.45F;

            t = typeof(int);
            Console.Write(t.ToString() + "  ");
            Console.WriteLine(i.GetType());

            t = typeof(float);
            Console.Write(t.ToString() + "  ");
            Console.WriteLine(f.GetType());
            Console.ReadLine();

        }
    }
}

// typeof(int) ifadesi, int türünü Type nesnesi olarak döndürür.
// i.GetType() ise i değişkeninin türünü çalıştırma zamanında alır.
// int türü System.Int32 olarak ve float türü System.Single olarak görüntülenir.
// Bu kodun amacı, typeof ve GetType() kullanarak çalışma zamanında veya sabit 
// olarak değişkenlerin tür bilgisini elde etmektir.
