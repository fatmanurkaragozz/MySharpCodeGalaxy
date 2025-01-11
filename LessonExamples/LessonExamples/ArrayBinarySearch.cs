using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class ArrayBinarySearch
    {
        static void Main()
        {
            string[] dizi = { "Zeynep", "Fatma", "Ali", "Yılmaz", "Gökhan", "Osman", "Feride" };

            Console.Write("Aranacak ismi giriniz : ");
            string isim = Console.ReadLine();

            Array.Sort(dizi);
            int indeks = Array.BinarySearch(dizi, isim);

            if(indeks < 0)
            {
                Console.WriteLine("Aranan isim dizide bulunamadı!");
            }
            else
            {
                Console.WriteLine("Aranan isim dizinin {0}. elemanında bulundu...", indeks);
            }

            Console.ReadLine();
        }
    }
}
