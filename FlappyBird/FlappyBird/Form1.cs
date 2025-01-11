using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class scoreText : Form
    {
        // Değişkenlerin tanımlanması
        int pipeSpeed = 8; // Boruların hareket hızı
        int gravity = 15;  // Kuşa etki eden yerçekimi (kuşu aşağı çeker)
        int score = 0;     // Oyuncunun puanını tutar

        // Formun kurucu fonksiyonu
        public scoreText()
        {
            InitializeComponent(); // Formun bileşenlerini başlatır
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        // Zamanlayıcı (timer) her tetiklendiğinde bu fonksiyon çalışır
        private void gameTimerEvent(object sender, EventArgs e)
        {
            // Kuşun dikey pozisyonunu yerçekimi etkisine göre ayarla
            flappyBird.Top += gravity;   

            pipeBottom.Left -= pipeSpeed; // Alt boru sola doğru hareket eder
            pipeTop.Left -= pipeSpeed;    // Üst boru sola doğru hareket eder

            // Puanı ekranda güncelle
            scoreLabel.Text = "Score: " + score;

            // Alt boru ekranın dışına çıktıysa (soldan kaybolduğunda) boruyu sağa yeniden yerleştir
            if(pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800; // Alt boruyu sağdan geri getir
                score++;               // Puanı artır
            }

            // Üst boru ekranın dışına çıktıysa boruyu sağa geri yerleştir
            if(pipeTop.Left < -180)
            {
                pipeTop.Left = 950;   // Üst boruyu sağdaan geri getir
                score++;              // Puanı artır  
            }

            // Eğer kuş bir engelle ya da yerle çarpışırsa, oyunu bitir
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || // Alt boruya çarpma
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || // Üst boruya çarpma
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||  // Yere çarpma 
                flappyBird.Top < -25 ) // Ekranın üst sınırını aşarsa
            {
                endGame(); // Oyunu bitiren fonksiyon çağrılır
            }

            // Eğer oyuncunun puanı 5'i geçerse boruların hızı artırılır
            if(score > 5)
            {
                pipeSpeed = 15; // Boru hızını artırarak oyunu zorlaştır
            }
        }

        // Oyuncu boşluk tuşuna bastığında bu fonksiyon çalışır
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space) // Boşluk tuşuna basıldığında
            {
                gravity = -15; // Kuşu yukarı çıkarmak için yerçekimini tersine çevir
            }

        }

        // Oyuncu boşluk tuşunu bıraktığında bu fonksiyon çalışır
        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space) // Boşluk tuşu bırakıldığında 
            {
                gravity = 15; // Yerçekimi tekrar pozitif olur (kuş aşağı düşer)
            }

        }

        // Oyunun bitişini işleyen fonksiyon
        private void endGame()
        {
            gameTimer.Stop(); // Zamanlayıcıyı durdurarak oyunu durdurur
            scoreLabel.Text += " Game over !!!"; // "Game over" mesajını puanın yanına ekle
        }
    }
}

// ÖZET:
// GİRİŞ (Input):
// - Kullanıcı boşluk tuşuna basarak (gamekeyisdown) ve bırakarak (gamekeyisup) kuşun hareketini kontrol eder.
// - Başlangıçta boru hızı, yerçekimi, ve puan gibi veriler tanımlanır.

// ÇIKIŞ (Output):
// - Puan bilgisini ekranda gösterir: "Score: X".
// - Oyun bittiğinde "Game over !!!" mesajı gösterilir.

// KONTROL (Control):
// - Kuşun borulara, zemine çarpması veya ekranın üst sınırını aşması oyunu bitirir.
// - Borular ekran dışına çıktığında sağdan yeniden eklenir ve puan artırılır.
// - Puan 5’i geçtiğinde boru hızı artırılarak oyun zorlaştırılır.

// TEKRAR (Loop/Iteration):
// - Zamanlayıcı (`gameTimerEvent`) her tick'inde oyunun durumunu günceller.

// MATEMATİK (Math/Calculations):
// - Kuşun dikey pozisyonu yerçekimi ile değiştirilir: `flappyBird.Top += gravity`.
// - Borular her karede sola doğru hareket eder: `pipeBottom.Left -= pipeSpeed`.
// - Puan artırma: `score++`.
