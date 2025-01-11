using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class MatrixArray
    {
        static void Main()
        {
            int[,] dizi = { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            for (int i = 0; i < 3; i++) // Satırlar 3 tane
            {
                for(int j = 0; j < 2; j++) // Sütunlar 2 tane
                {
                    Console.WriteLine(dizi[i, j]); // Her bir elemanı yazdır
                }
            }

            Console.ReadLine();
        }
    }
}
