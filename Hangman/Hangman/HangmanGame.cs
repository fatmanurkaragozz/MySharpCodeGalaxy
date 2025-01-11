using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    // HangmanGame sınıfı, hangman oyununu yöneten temel işlevselliği kapsar.
    class HangmanGame
    {
        // Türkiye'nin 81 ilini içeren dizi
        public string[] Cities = new string[]
        {
            "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya",
            "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik",
            "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
            "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep",
            "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir",
            "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli",
            "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin",
            "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun",
            "Şanlıurfa", "Siirt", "Sinop", "Şırnak", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli",
            "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak"
        };

        // Seçilen gizli kelimeyi tutan özellik
        public string SecretWord { get; private set; }

        // Kullanıcının tahmin ettiği harfleri tutan liste / gussed:tahmin, letters:harfler
        public List<char> GuessedLetters { get; private set; }

        // Kalan tahmin haklarını tutan özellik / remaining: kalan, attemps: deneme
        public int RemainingAttempts { get; private set; }

        // Rastgele kelime seçimi için kullanılan Random nesnesi
        private Random random;

        public HangmanGame()
        {
            random = new Random(); // Rastgele sayı üreteci başlatılır
            GuessedLetters = new List<char>(); // Tahmin edilen harfler listesi başlatılır
            RemainingAttempts = 6; // Örneğin, 6 tahmin hakkı
            SelectRandomWord(); // Rastgele bir kelime seçilir
        }

        // Rastgele bir kelime seçmek için kullanılan metot
        public void SelectRandomWord()
        {
            // Cities dizisinden rastgele bir şehir seçilir ve küçük harfe dönüştürülür
            SecretWord = Cities[random.Next(Cities.Length)].ToLower();
        }

        // Kullanıcının bir harf tahmin etmesi için kullanılan metot
        public bool Guess(char letter)
        {
            letter = char.ToLower(letter); // Harf küçük harfe dönüştürülür
            // Eğer harf daha önce tahmin edildiyse, false döndür
            if (GuessedLetters.Contains(letter))
                return false;

            // Tahmin edilen harfler listesine harf eklenir
            GuessedLetters.Add(letter);
            // Eğer gizli kelimede tahmin edilen harf yoksa, kalan tahmin hakkı bir azaltılır
            if (!SecretWord.Contains(letter))
            {
                RemainingAttempts--;  // Kalan tahmin hakkını azalt
                return false; // Yanlış tahmin
            }

            return true;  // Doğru tahmin
        }

        // Oyunun kazanılıp kazanılmadığını kontrol etmek için kullanılan metot
        public bool IsGameWon()
        {
            // Gizli kelimedeki tüm harfler, tahmin edilen harfler arasında mı kontrol edilir
            return SecretWord.All(c => GuessedLetters.Contains(c));
        }

        // Oyunun bitip bitmediğini kontrol etmek için kullanılan metot
        public bool IsGameOver()
        {
            // Eğer kalan tahmin hakkı 0 veya daha az ise oyun bitmiştir
            return RemainingAttempts <= 0;
        }
    }
}

