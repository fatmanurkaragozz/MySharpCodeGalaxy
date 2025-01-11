using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading.Indexers
{
    // Satranç Tahtası Sınıfı
    class ChessBoard
    {
        // Satranç tahtasını temsil eden 8x8 matris
        private string[,] board = new string[8, 8];

        // Kurucu metot: Tahtayı başlatır ve her kareyi boş yapar
        public ChessBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = "Boş"; // Başlangıçta tüm kareler boş
                }
            }
        }

        // Çift boyutlu indeksleyici: Satranç tahtasındaki taşları yönetir
        public string this[int row, int col]
        {
            get
            {
                // Satranç tahtasının sınırları dışında erişim kontrolü
                if (row < 0 || row >= 8 || col < 0 || col >= 8)
                {
                    return "Hata: Geçersiz kare!";
                }
                return board[row, col]; // Karedeki taşı döndürür
            }
            set
            {
                // Satranç tahtasının sınırları dışında erişim kontrolü
                if (row < 0 || row >= 8 || col < 0 || col >= 8)
                {
                    Console.WriteLine("Hata: Geçersiz kare!");
                }
                else
                {
                    // Kareye belirtilen taşı yerleştirir
                    board[row, col] = value;
                    Console.WriteLine($"({row}, {col}) konumuna '{value}' yerleştirildi.");
                }
            }
        }

        // Satranç tahtasının tamamını yazdıran metot
        public void PrintBoard()
        {
            Console.WriteLine("\nSatranç Tahtası:");
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Console.Write(board[row, col].PadRight(10)); // Her taşı düzgün hizalama ile gösterir
                }
                Console.WriteLine();
            }
        }
    }

    class Program7
    {
        static void Main(string[] args)
        {
            // Satranç tahtası nesnesi oluşturulur
            ChessBoard chessBoard = new ChessBoard();

            // Tahtayı yazdır (başlangıçta boş)
            chessBoard.PrintBoard();

            // Tahtaya bazı taşlar eklenir
            chessBoard[0, 0] = "Kale";
            chessBoard[0, 1] = "At";
            chessBoard[0, 2] = "Fil";
            chessBoard[0, 3] = "Vezir";
            chessBoard[0, 4] = "Şah";
            chessBoard[1, 0] = "Piyon";
            chessBoard[7, 7] = "Kale";

            // Geçerli bir karedeki taş kontrol edilir
            Console.WriteLine($"\n(0, 3) konumundaki taş: {chessBoard[0, 3]}");

            // Geçersiz bir kareye erişim kontrolü
            Console.WriteLine(chessBoard[8, 8]); // Hata verecektir

            // Güncellenmiş satranç tahtasını yazdır
            chessBoard.PrintBoard();

            Console.ReadLine();
        }
    }
}
