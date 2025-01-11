using System;
using System.Collections.Generic;

namespace Zarva
{
    class Program
    {
        static void Main(string[] args)
        {
            // Labirent boyutlarını tanımlıyoruz
            int M = 20; // Labirent yüksekliği
            int N = 20; // Labirent genişliği

            // Başlangıç noktasından hedef noktaya ulaşmaya çalışıyoruz
            if (FindPath(M, N))
            {
                Console.WriteLine("Hedefe ulaşmak mümkün.");
            }
            else
            {
                Console.WriteLine("Şehir kayboldu!");
            }

            // Konsolun kapanmaması için, kullanıcının bir tuşa basmasını bekliyoruz
            Console.ReadLine();
        }

        // BFS ile labirent içinde hedefe ulaşılabilir bir yol olup olmadığını kontrol eden metot
        static bool FindPath(int M, int N)
        {
            // Dört farklı yön tanımlıyoruz: yukarı, aşağı, sol, sağ
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            // Ziyaret edilen hücreleri izlemek için 2 boyutlu bir dizi
            bool[,] visited = new bool[M, N];

            // BFS için bir kuyruk oluşturuyoruz. Her öğe, mevcut konum (x, y) ve o ana kadar olan yolu içeriyor
            Queue<(int, int, List<(int, int)>)> queue = new Queue<(int, int, List<(int, int)>)>();
            queue.Enqueue((0, 0, new List<(int, int)> { (0, 0) })); // Başlangıç noktası (0,0) ile kuyruğa ekleniyor
            visited[0, 0] = true; // Başlangıç noktası ziyaret edildi olarak işaretleniyor

            // BFS döngüsü: kuyruk boşalana kadar devam eder
            while (queue.Count > 0)
            {
                // Kuyruğun başındaki elemanı alıyoruz
                var (x, y, path) = queue.Dequeue();

                // Eğer hedef noktaya ulaştıysak (M-1, N-1), başarılı sonucu gösteriyoruz
                if (x == M - 1 && y == N - 1)
                {
                    Console.WriteLine("Yol bulundu:");
                    foreach (var step in path)
                    {
                        Console.WriteLine($"({step.Item1}, {step.Item2})");
                    }
                    return true;
                }

                // Mevcut konumdan dört farklı yöne gidilme durumunu kontrol ediyoruz
                for (int i = 0; i < 4; i++)
                {
                    int newX = x + dx[i];
                    int newY = y + dy[i];

                    // Yeni konum geçerli sınırlar içinde mi ve ziyaret edilmemiş mi kontrol ediyoruz
                    if (newX >= 0 && newX < M && newY >= 0 && newY < N && !visited[newX, newY])
                    {
                        // Hücre geçerli mi: hem x hem y asal basamaklardan oluşmalı ve x + y, x * y'ye bölünebilmeli
                        if (IsPrimeDigits(newX) && IsPrimeDigits(newY) && IsDivisible(newX, newY))
                        {
                            visited[newX, newY] = true; // Yeni hücreyi ziyaret edildi olarak işaretliyoruz
                            var newPath = new List<(int, int)>(path) { (newX, newY) }; // Yeni yolu oluşturuyoruz
                            queue.Enqueue((newX, newY, newPath)); // Yeni konumu ve güncellenmiş yolu kuyruğa ekliyoruz
                        }
                    }
                }
            }

            // Eğer döngü bitmişse ve hedefe ulaşılmamışsa, ulaşmak mümkün değil
            return false;
        }

        // Sayının tüm basamaklarının asal olup olmadığını kontrol eden metot (yalnızca 2, 3, 5, veya 7'yi içerebilir)
        static bool IsPrimeDigits(int num)
        {
            // Sayının her bir basamağını kontrol ediyoruz
            while (num > 0)
            {
                int digit = num % 10; // Son basamağı alıyoruz
                if (digit != 2 && digit != 3 && digit != 5 && digit != 7) // Asal değilse false döndür
                    return false;
                num /= 10; // Bir sonraki basamağa geçiyoruz
            }
            return true; // Tüm basamaklar asalsa true döner
        }

        // x + y'nin x * y'ye bölünüp bölünmediğini kontrol eden metot
        static bool IsDivisible(int x, int y)
        {
            // Bölme hatalarını önlemek için x * y'nin sıfır olmadığı durumları kontrol ediyoruz
            if (x * y == 0) return false;
            return (x + y) % (x * y) == 0; // Bölünebilirse true, aksi halde false döner
        }
    }
}
