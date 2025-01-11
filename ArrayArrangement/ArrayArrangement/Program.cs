using System;

namespace ArrayArrangement
{
    class Program
    {
        static void Main(string[] args)
        {
            // GİRİŞ: Kullanıcıdan dizinin boyutunu alma
            Console.Write("Dizinin boyutunu giriniz: ");
            int boyut = Convert.ToInt32(Console.ReadLine());  // Kullanıcının girdiği boyutu alır

            // GİRİŞ: Kullanıcıdan alınacak dizi
            int[] dizi = new int[boyut];  // Boyuta göre dizi oluşturuluyor

            // TEKRAR: Dizinin elemanlarını kullanıcıdan alma
            for (int i = 0; i < boyut; i++)
            {
                Console.Write($"Dizinin {i}. elemanını giriniz: ");
                dizi[i] = Convert.ToInt32(Console.ReadLine());  // Kullanıcıdan dizi elemanlarını alıyoruz
            }

            // MATEMATİK: Diziyi büyükten küçüğe sıralama işlemi (Selection Sort Algoritması)
            for (int i = 0; i < boyut - 1; i++)
            {
                int enBuyukInd = i;  // Şu anki en büyük elemanın indeksi
                for (int j = i + 1; j < boyut; j++)
                {
                    // KONTROL: Daha büyük bir eleman varsa indeksi güncelle
                    if (dizi[j] > dizi[enBuyukInd])
                    {
                        enBuyukInd = j;  // En büyük elemanı bulduk, indeksini kaydettik
                    }
                }

                // DEĞİŞİM: Bulunan en büyük elemanı mevcut yer ile takas et
                int temp = dizi[i];
                dizi[i] = dizi[enBuyukInd];
                dizi[enBuyukInd] = temp;
            }

            // ÇIKIŞ: Sıralanmış diziyi ekrana yazdırma
            Console.WriteLine("Sıralanmış dizi:");
            for (int i = 0; i < boyut; i++)
            {
                Console.Write(dizi[i] + " ");  // Dizi elemanlarını ekrana yazdırır
            }
            Console.WriteLine();

            // GİRİŞ: Kullanıcıdan aranacak sayıyı alma
            Console.Write("Bir sayı giriniz: ");
            int sayi = Convert.ToInt32(Console.ReadLine());  // Kullanıcıdan aramak istediği sayı alınıyor

            // İkili arama fonksiyonunu çağırma
            int sonuc = IkiliArama(dizi, sayi);

            // KONTROL ve ÇIKIŞ: Sonucu ekrana yazdırma
            if (sonuc != -1)  // Sayı bulunduysa
            {
                Console.WriteLine($"Sayı bulundu. İndis: {sonuc}");
                Console.ReadLine();  // Ekranın kapanmasını önlemek için bekleme
            }
            else  // Sayı bulunamadıysa
            {
                Console.WriteLine("Sayı dizide mevcut değil.");
                Console.ReadLine();  // Ekranın kapanmasını önlemek için bekleme
            }
        }

        // İkili arama algoritması
        static int IkiliArama(int[] dizi, int sayi)
        {
            int sol = 0;  // Aramanın başladığı indeks (sol sınır)
            int sag = dizi.Length - 1;  // Aramanın bittiği indeks (sağ sınır)

            // TEKRAR: Sol sınır sağ sınırdan küçük veya eşit olduğu sürece arama devam eder
            while (sol <= sag)
            {
                // MATEMATİK: Orta indeksi hesapla
                int orta = (sol + sag) / 2;

                // KONTROL: Aranan sayı bulundu mu?
                if (dizi[orta] == sayi)
                {
                    return orta;  // Sayı bulundu, indeksini döndür
                }
                // Aranan sayı orta elemandan küçükse arama aralığını daralt
                else if (dizi[orta] < sayi)
                {
                    sag = orta - 1;  // Sağ sınırı orta indeksin bir öncesine al
                }
                // Aranan sayı orta elemandan büyükse arama aralığını daralt
                else
                {
                    sol = orta + 1;  // Sol sınırı orta indeksin bir sonrasına al
                }
            }

            return -1;  // Sayı bulunamadıysa -1 döndür
        }
    }
}
