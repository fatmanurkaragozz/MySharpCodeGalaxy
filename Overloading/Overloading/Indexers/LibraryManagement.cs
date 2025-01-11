using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading.Indexers
{
    class LibraryManagement
    {
        // Kitap koleksiyonu bir dizi olarak tanımlanır
        private string[] books;

        // Sınıfın kurucusu (constructor), başlangıçta kitap koleksiyonunu alır
        public LibraryManagement(string[] initialBooks)
        {
            books = initialBooks; // Başlangıç kitaplarını koleksiyona ekler
        }

        // Tek boyutlu indeksleyici
        public string this[int index]
        {
            get
            {
                // Geçersiz indeks kontrolü
                if (index < 0 || index >= books.Length)
                {
                    return "Hata: Geçersiz indeks!"; // Hata mesajı döndürülür
                }
                return books[index]; // İlgili indeksteki kitabı döndürür
            }
            set
            {
                // Geçersiz indeks kontrolü
                if (index < 0 || index >= books.Length)
                {
                    Console.WriteLine("Hata: Geçersiz indeks!"); // Hata mesajı yazdırılır
                }
                else
                {
                    books[index] = value; // İlgili indeksteki kitabın adı değiştirilir
                }
            }
        }

        // Koleksiyondaki kitapları listeleyen bir metot
        public void ListBooks()
        {
            Console.WriteLine("Kitap Listesi:");
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"{i}: {books[i]}");
            }
        }
    }
    class Program5
    {
        static void Main(string[] args)
        {
            // Başlangıçta bazı kitaplarla kitaplık oluşturulur
            string[] initialBooks = { "Kitap 1", "Kitap 2", "Kitap 3" };
            LibraryManagement library = new LibraryManagement(initialBooks);

            // Kitap listesini gösterir
            library.ListBooks();

            // Geçerli bir indeksten kitabı okuma
            Console.WriteLine("\n0. indeksteki kitap: " + library[0]);

            // Geçerli bir indekste kitabın adını değiştirme
            library[1] = "Yeni Kitap 2";
            Console.WriteLine("\n1. indeksteki kitap güncellendi.");

            // Geçersiz bir indeksten erişim
            Console.WriteLine("\n10. indeksteki kitap: " + library[10]);

            // Güncellenen kitap listesini gösterir
            Console.WriteLine("\nGüncellenmiş Kitap Listesi:");
            library.ListBooks();

            Console.ReadLine();
        }
    }
}
