using System;
using DevExpress.Xpo;

namespace LessonExamples
{

    public class ForLoop5 : XPObject
    {
        public ForLoop5() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public ForLoop5(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        static void Main()
        {
            int k, t, toplam, n1, n2;

            Console.Write("Aralık başlangıcı : ");
            n1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Aralık sonu : ");
            n2 = Convert.ToInt32(Console.ReadLine());




            if ( n1 <= n2)
            {
                for(k = n1; k<= n2; k++)
                {
                    toplam = 0;

                    for(t = 1; t <= k; t++)
                    {
                        if (k % t == 0)
                        {
                            toplam = toplam + t;
                        }
                        if(toplam == k + 1)
                        {
                            Console.WriteLine(k);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Geçerli bir aralık giriniz...");
            }

            Console.ReadLine();
        }
        
    }

}