using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LessonExamples
{
    class MyArrayList
    {
        static void Main(string[] args)
        {
            ArrayList liste = new ArrayList();
            liste.Add("Ahmet");
            liste.Add(34);
            liste.Add('A');
            liste.Remove('A');

            foreach(object s in liste)
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }
    }
}
