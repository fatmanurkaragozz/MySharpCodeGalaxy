using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
// Browse sekmesine gidin ve System.ValueTuple arayın. ( Değer Tipi)
// Bulunan paketi yükleyin ve projeye dahil edin.

namespace NodeRecoveryWithRobots
{
    class TechCityRescue
    {

        // Grid boyutları
        static int N; // Izgaranın boyutunu tutar

        // Yön vektörleri: yukarı, aşağı, sol, sağ
        static int[] dx = { -1, 1, 0, 0 }; // Y ekseni yönü
        static int[] dy = { 0, 0, -1, 1 }; // X ekseni yönü

        // Robotların gridde kaç düğüm kurtaracağını hesaplayan fonksiyon
        public static int MaxSavedNodes(int[,] grid, List<(int, int)> robotStarts)
        {
            N = grid.GetLength(0);  // Grid boyutunu al

            // Kurtarılan düğümleri takip etmek için bir set
            HashSet<(int, int)> visited = new HashSet<(int, int)>(); // Ziyaret edilen düğümleri saklar

            // Tüm robotların toplam kurtardığı düğümleri tutan sayaç
            int totalSavedNodes = 0;

            // BFS: Breadth-First Search (Genişlik Öncelikli Arama)
            // Bu algoritma, bir graf veya ağaç yapısında en kısa yol veya belirli bir düğüm aramak için 
            // kullanılan etkili bir tarama yöntemidir

            //            BFS Algoritmasının Temel Özellikleri
            //Kuyruk Kullanımı
            //BFS, sırayla işlenmesi gereken düğümleri saklamak için bir kuyruk(queue) veri yapısı kullanır.Bu, düğümlerin sırasıyla işlenmesini sağlar.

            //Düğüm Ziyareti:
            //Başlangıç düğümünden başlayarak, algoritma her seferinde öncelikle en yakın(yani aynı seviyedeki) düğümleri ziyaret eder.
            //Ziyaret edilen düğümler bir set veya dizi ile kaydedilir, böylece aynı düğüm bir daha ziyaret edilmez.

            //Seviye Taraması:
            //BFS, bir düğümden komşularına(yani, o düğümle doğrudan bağlantılı olan düğümler) geçerek, her seferinde bir seviye daha derinlemesine 
            //inerek çalışır. Bu, onu derinlik öncelikli arama(DFS) algoritmasından ayırır.

            // Her robot için BFS başlat
            foreach (var (startX, startY) in robotStarts)
            {
                totalSavedNodes += BFS(grid, startX, startY, visited); // BFS ile kurtarılan düğümleri say
            }

            return totalSavedNodes; // Toplam kurtarılan düğüm sayısını döndür
        }

        // BFS algoritması ile bir robotun müdahale edebildiği düğümleri sayar
        private static int BFS(int[,] grid, int startX, int startY, HashSet<(int, int)> visited)
        {
            // Eğer başlangıç düğümü zarar görmüşse (0) işlem yapma
            if (grid[startX, startY] == 0 || visited.Contains((startX, startY)))
                return 0; // Ziyaret edilmiş veya zarar görmüşse sıfır döndür

            // Contains metodu, C# dilinde belirli bir koleksiyonda (örneğin, bir dizi, liste veya set 
            // gibi) belirli bir öğenin (elemanın) var olup olmadığını kontrol etmek için kullanılır. 
            // Bu bağlamda, visited adlı HashSet<(int, int)> koleksiyonunun bir parçasıdır

            // BFS için kuyruk yapısı (sıralı işlem)
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((startX, startY)); // Başlangıç noktasını kuyruğa ekle, queue = kuyruk
            visited.Add((startX, startY));  // Ziyaret edildi olarak işaretle

            // Enqueue, veri yapılarında özellikle kuşak (queue) yapılandırmasında kullanılan bir terimdir.
            // Kuşak, ilk giren ilk çıkar (FIFO - First In, First Out) prensibine göre çalışan bir veri
            // yapısıdır. Yani kuşağa eklenen (enqueue) ilk öğe, kuşaktan çıkarılan (dequeue) ilk öğe olacaktır.

            int savedNodes = 0; // Kurtarılan düğüm sayısını başlat

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue(); // Kuyruktan bir düğüm al
                savedNodes++;  // Kurtarılan düğüm sayısını artır

                // Komşuları kontrol et
                for (int i = 0; i < 4; i++)
                {
                    int newX = x + dx[i]; // Yeni X koordinatı
                    int newY = y + dy[i]; // Yeni Y koordinatı

                    // Yeni koordinatların geçerli olup olmadığını kontrol et
                    if (IsValid(newX, newY) && grid[newX, newY] == 1 && !visited.Contains((newX, newY)))
                    {
                        queue.Enqueue((newX, newY)); // Geçerli ve kurtarılabilir düğümü kuyruğa ekle
                        visited.Add((newX, newY));  // Ziyaret edildi olarak işaretle
                    }
                }
            }

            return savedNodes; // Kaydedilen düğümler. Kurtarılan düğüm sayısını döndür
        }

        // Koordinatların geçerli olup olmadığını kontrol eden fonksiyon
        private static bool IsValid(int x, int y)
        {
            return x >= 0 && x < N && y >= 0 && y < N; // Koordinatların ızgara sınırları içinde olup olmadığını kontrol et
        }

        // Ana fonksiyon (programın başlangıç noktası)
        public static void Main(string[] args)
        {
            // Örnek grid
            int[,] grid = {
            { 1, 1, 0, 1 },  // Düğüm 1
            { 0, 1, 0, 0 },  // Düğüm 2
            { 1, 1, 1, 0 },  // Düğüm 3
            { 0, 0, 1, 1 }   // Düğüm 4
        };

            // Robotların başlangıç pozisyonları
            List<(int, int)> robotStarts = new List<(int, int)>
        {
            (0, 0),  // Robot 1'in başlangıç konumu
            (2, 2),  // Robot 2'in başlangıç konumu
            (3, 3)   // Robot 3'in başlangıç konumu
        };

            // Sonucu hesapla
            int result = MaxSavedNodes(grid, robotStarts); // Kurtarılan düğüm sayısnı hesapla
            Console.WriteLine($"Toplam kurtarılan düğüm sayısı: {result}"); // Sonucu ekrana yazdır
            Console.ReadLine(); // Konsolun kapanmasını engelle

        }
    }
}
