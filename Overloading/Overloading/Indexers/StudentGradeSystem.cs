using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading.Indexers
{
    // Öğrenci Not Sistemi sınıfı
    class StudentGradeSystem
    {
        
            // Ders ve notlarını depolamak için sözlük kullanıyoruz
            private Dictionary<string, int> grades = new Dictionary<string, int>();

            // Not eklemek için bir metot
            public void AddGrade(string course, int grade)
            {
                // Ders daha önce eklenmemişse ekler
                if (!grades.ContainsKey(course))
                {
                    grades[course] = grade;
                    Console.WriteLine($"{course} dersi için not eklendi: {grade}");
                }
                else
                {
                    Console.WriteLine($"{course} dersi zaten mevcut! Not güncelleniyor...");
                    grades[course] = grade; // Eğer ders zaten varsa not güncellenir
                }
            }

            // Ders adına göre notlara erişim sağlayan indeksleyici
            public int this[string course]
            {
                get
                {
                    // Eğer ders varsa notu döndürür
                    if (grades.ContainsKey(course))
                    {
                        return grades[course];
                    }
                    else
                    {
                        Console.WriteLine("Hata: Bu ders mevcut değil!");
                        return -1; // Hata durumunda negatif bir değer döndürür
                    }
                }
                set
                {
                    // Eğer ders yoksa, not eklenir
                    if (!grades.ContainsKey(course))
                    {
                        Console.WriteLine($"{course} dersi bulunamadı. Yeni ders olarak ekleniyor.");
                        grades[course] = value;
                    }
                    else
                    {
                        // Eğer ders mevcutsa not güncellenir
                        grades[course] = value;
                        Console.WriteLine($"{course} dersi için not güncellendi: {value}");
                    }
                }
            }

            // Tüm dersleri ve notlarını listeleyen metot
            public void ListGrades()
            {
                Console.WriteLine("\nÖğrenci Not Listesi:");
                foreach (var grade in grades)
                {
                    Console.WriteLine($"{grade.Key}: {grade.Value}");
                }
            }
        

        class Program6
        {
            static void Main(string[] args)
            {
                // Öğrenci not sistemi nesnesi oluşturuyoruz
                StudentGradeSystem studentGrades = new StudentGradeSystem();

                // Bazı derslerin notlarını ekliyoruz
                studentGrades.AddGrade("Matematik", 85);
                studentGrades.AddGrade("Fizik", 90);
                studentGrades.AddGrade("Kimya", 78);

                // Notları listeliyoruz
                studentGrades.ListGrades();

                // İndeksleyici ile not sorgulama
                Console.WriteLine("\nMatematik Notu: " + studentGrades["Matematik"]);

                // Geçersiz ders sorgulama
                Console.WriteLine("Biyoloji Notu: " + studentGrades["Biyoloji"]);

                // Not güncelleme
                studentGrades["Fizik"] = 95;
                Console.WriteLine("\nFizik Notu Güncellendi: " + studentGrades["Fizik"]);

                // Yeni bir ders ekleme
                studentGrades["Biyoloji"] = 80;

                // Güncellenmiş notları gösterme
                studentGrades.ListGrades();

                Console.ReadLine();
            }
        }
    }
}
