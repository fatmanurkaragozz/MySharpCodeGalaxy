using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLS
{
    internal class UML3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.ReadLine();
        }
    }

    // Protocol Identifiable
    public interface Identifiable
    {
        // Bir UUID metodu yaz ve bu metodu uygula
        Guid id { get; }
    }

    // Protocol Experienced
    public interface Experienced
    {
    }

    // Aşı sınıfı
    public class Vaccine
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    // Hayvan bilgileri sınıfı
    public class PetInformation
    {
        public List<string> traits { get; set; } = new List<string>();
        public List<Vaccine> vaccines { get; set; } = new List<Vaccine>();
    }

    // Hayvan sınıfı
    public class Animal
    {
        public string type { get; set; }
        public string breed { get; set; }
        public bool carnivore { get; set; }
    }

    // Sahip sınıfı
    public class Owner : Experienced
    {
        public string name { get; set; }
    }

    // Hayvan sınıfı
    public class Pet : Identifiable
    {
        // Id is a UUID
        public Guid id { get; } = Guid.NewGuid();
        private string name { get; set; }
        private int age { get; set; }
        private Owner owner { get; set; }
        private Animal type { get; set; }
        private PetInformation petInfo { get; set; }

        // Besleme işlemi
        public void feed()
        {
            // Besleme işlemiS
        }

        // Yemek yiyen hayvan mı?
        private bool isHerbivore()
        {
            return !type.carnivore;
        }
    }
}
