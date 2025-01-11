using System;
using System.Collections.Generic;

namespace MazeSolver
{

    // Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
    // Browse sekmesine gidin ve System.ValueTuple arayın. ( Değer Tipi)
    // Bulunan paketi yükleyin ve projeye dahil edin.

    class Program
    {
        static void Main(string[] args)
        {
            // Labirent örneği (1'ler yürünebilen yolları, 0'lar tuzak veya duvarları temsil eder)
            int[,] maze = {
                { 1, 0, 0, 0 },
                { 1, 1, 0, 1 },
                { 0, 1, 1, 1 },
                { 0, 0, 0, 1 }
            };

            // Lbirentteki en kısa yolu bulan fonksiyonunu çağır
            int result = ShortestPath(maze);

            // Sonuç kontrolü: Eğer -1 değilse, hazineye ulaşılmış demektir
            if (result != -1)
            {
                // Hazineye ulaşmak için gereken adım sayısını yazdır
                Console.WriteLine($"En Kısa Yol: {result} adım");
            }
            else
            {
                // Hazineye ulaşmanın mümkün olmadığını belirt
                Console.WriteLine("Yol Yok");
            }
            // Konsolun kapanması için bir tuşa basmayı bekle
            Console.ReadLine();
         }

        // En kısa yolu bulan fonksiyon
        public static int ShortestPath(int[,] maze)
        {
            int N = maze.GetLength(0); // Labirentin boyutunu al (N * N)

            // Hareket yönlerini temsil eden vektörler: yukarı, aşağı, sola, sağa
            int[] dx = { -1, 1, 0, 0 }; // x koordinat değişimi
            int[] dy = { 0, 0, -1, 1 }; // y koordinat değişimi

            // BFS için kuyruk (Queue) ve ziyaret edilen hücreler seti (HashSet) oluştur
            Queue<(int, int, int)> queue = new Queue<(int, int, int)>(); // (x, y, adım sayısı)
            HashSet<(int, int)> visited = new HashSet<(int, int)>(); // Ziyaret edilen hücrelerin seti

            // Başlangıç hücresini (0, 0) kuyruğa ekle ve ziyaret edildi olarak işaretle
            queue.Enqueue((0, 0, 0)); // Adım sayısını 0 olarak başlat
            visited.Add((0, 0));

            // Kuyruk boş olmadığı sürece döngü devam et
            while (queue.Count > 0)
            {
                // Kuyrukta bir hücreyi çıkar (x,y) koordinatları ve adım sayısını al
                var (x, y, steps) = queue.Dequeue();

                // Hedefe ulaşıp ulaşılmadığını kontrol et
                if (x == N - 1 && y == N - 1)
                {
                    return steps; // En kısa yolun adım sayısını döndür
                }

                // Mevcut hüvrenin komşu hücrelerini kontrol et
                for (int i = 0; i < 4; i++)
                {
                    // Yeni koordinatları hesapla
                    int newX = x + dx[i]; // x koordinatını güncelle
                    int newY = y + dy[i]; // y koordinatını güncelle

                    // Yeni hücrenin geçerli olup olmadığını kontrol et
                    if (IsValid(newX, newY, N, maze, visited))
                    {
                        // Eğer geçerliyse, yeni hücreyi kuyruğa ekle ve ziyaret edildi olarak işaretle
                        queue.Enqueue((newX, newY, steps + 1)); // Adım sayısnı 1 arttır
                        visited.Add((newX, newY)); // Ziyaret edildi olarak işaretle
                    }
                }
            }

            return -1; // Hedefe ulaşılamıyorsa -1 döndür
        }

        // Geçerli hücre kontrol fonksiyonu
        private static bool IsValid(int x, int y, int N, int[,] maze, HashSet<(int, int)> visited)
        {
            // Koordinatların geçerli aralıkta olup olmadığını ve hücrenin 1 ( geçilebilir) olup olmadığını kontrol et
            return x >= 0 && x < N && y >= 0 && y < N && maze[x, y] == 1 && !visited.Contains((x, y));
            
        }
    }
}
