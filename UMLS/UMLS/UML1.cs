using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLS
{
    class UML1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.ReadLine();
        }
    }
    public class Address
    {
        public string street { get; set; } // Cadde
        public string city { get; set; } // Şehir
        public string state { get; set; } // Eyalet
        public int postalCode { get; set; } // Posta kodu
        public string country { get; set; } // Ülke

        // Adres doğrulama metodu
        private bool validate()
        {
            // Bu alana adres doğrulama işlemi yazılacak    
            return true;
        }

        // Adresi etiket olarak döndüren metot
        public string outputAsLabel()
        {
            // Bu alana adresi etiket olarak döndüren kod yazılacak
            return $"Address: {street}, {city}, {state}, {postalCode}, {country}";
        }
    }

    // Person sınıfı
    public class Person
    {
        public string name { get; set; } // Ad
        public string phoneNumber { get; set; } // Telefon numarası
        public string emailAddress { get; set; } // E-posta adresi
        public Address personAddress { get; set; } // Adres

        // Park izni satın alma metodu
        public void purchaseParkingPass()
        {
            // Bu alana park izni satın alma işlemi yazılacak    
        }
    }

    // Öğrenci sınıfı (Student) Person sınıfından türetilmiştir
    public class Student : Person
    {
        public int studentNumber { get; set; } // Öğrenci numarası
        public int averageMark { get; set; } // Ortalama not

        // UML diyagramında metotun isminin altı çizili olması metotun static olduğunu gösterir.
        public static bool isEligibleToEnroll(string course)
        {
            // Bu alana kursa kayıt olma koşullarını kontrol eden kod yazılacak
            return true;
        }

        public int getSeminarsTaken()
        {
            // Bu alana alınan seminer sayısını döndüren kod yazılacak
            return 0;
        }
    }

    // Profesör sınıfı (Professor) Person sınıfından türetilmiştir
    public class Professor : Person
    {
        // salary diyagramda derived (türetilmiş) olarak belirtilmiştir.
        public int salary
        {
            get
            {
                // Örnek Maaş hesaplama mantığı: Yıllık hizmet süresi ve ders sayısına bağlı olarak hesaplanır
                return (yearsOfService * 2000) + (numberOfClasses * 1500);
            }
        }
        protected int staffNumber { get; set; } // Personel numarası
        private int yearsOfService { get; set; } // Hizmet yılı
        public int numberOfClasses { get; set; } // Verilen ders sayısı

        // Profesörün denetlediği öğrenciler
        public List<Student> supervises { get; set; } = new List<Student>();

        public void Supervise(Student student)
        {
            if (supervises.Count < 5)
            {
                supervises.Add(student);
            }
            else
            {
                throw new InvalidOperationException("Bir profesör en fazla 5 öğrenciyi denetleyebilir.");
            }
        }
       
    }

    
}
