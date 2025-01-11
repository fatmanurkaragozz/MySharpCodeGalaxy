using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading.Enums
{
    // Çalışan rolleri ve maaşları temsil eden enum
    public enum EmployeeRole
    {
        Manager,   // Yönetici
        Developer, // Yazılım Geliştirici
        Designer,  // Tasarımcı
        Tester     // Test Uzmanı
    }

    public class SalaryCalculator
    {
        // Çalışan rolüne göre maaşı hesaplayan metot
        public decimal CalculateSalary(EmployeeRole role)
        {
            // Rol bazlı maaş hesaplama
            switch (role)
            {
                case EmployeeRole.Manager:
                    return 10000m;  // Yönetici maaşı
                case EmployeeRole.Developer:
                    return 8000m;   // Yazılım geliştirici maaşı
                case EmployeeRole.Designer:
                    return 7000m;   // Tasarımcı maaşı
                case EmployeeRole.Tester:
                    return 6000m;   // Test uzmanı maaşı
                default:
                    return 0m;      // Geçersiz rol
            }
        }
    }

    public class Program14
    {
        public static void Main(string[] args)
        {
            // Maaş hesaplayıcı nesnesi oluşturuluyor
            var salaryCalculator = new SalaryCalculator();

            // Farklı roller için maaş hesaplamaları yazdırılıyor
            Console.WriteLine("Manager Salary: " + salaryCalculator.CalculateSalary(EmployeeRole.Manager));
            Console.WriteLine("Developer Salary: " + salaryCalculator.CalculateSalary(EmployeeRole.Developer));
            Console.WriteLine("Designer Salary: " + salaryCalculator.CalculateSalary(EmployeeRole.Designer));
            Console.WriteLine("Tester Salary: " + salaryCalculator.CalculateSalary(EmployeeRole.Tester));

            // Simülasyon tamamlandı bilgisi
            Console.WriteLine("Maaş hesaplamaları tamamlandı.");
            Console.ReadLine();
        }
    }
}
