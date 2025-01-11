using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    // Ana form sınıfı, Hangman oyunun görsel arayüzünü yönetir
    public partial class Form1 : Form
    {
        private HangmanGame game; // HangmanGame sınıfının bir örneği, oyunun durumunu tutar
        private List<Label> letterLabels; // Harfler için kullanılacak etiketler (Label)

        // Form1'in yapıcı metodu
        public Form1()
        {
            InitializeComponent(); // Form bileşenlerini başlatır
            pictureBoxHangman.Paint += pictureBoxHangman_Paint;

            // FlowLayoutPanel oluşturma ve form içine ekleme
            FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.Location = new Point(10, 10); // FlowLayoutPanel'in konumu
            flowLayoutPanel1.Size = new Size(500, 50); // Boyut
            flowLayoutPanel1.AutoSize = true; // Otomatik boyutlandırma

            this.Controls.Add(flowLayoutPanel1); // FlowLayoutPanel'i forma ekle

            game = new HangmanGame(); // Oyun sınıfını başlat
            CreateLetterLabels(); // Harf etiketlerini oluştur
            UpdateGameUI(); // Oyun arayüzünü güncelle
        }

        // Harfler için etiketleri (çizgileri) oluşturma metodu
        private void CreateLetterLabels()
        {
            letterLabels = new List<Label>(); // Yeni bir Label listesi oluştur 
            flowLayoutPanel1.Controls.Clear(); // FlowLayoutPanel içinde eski çizgileri temizle (Eğer varsa)

            // Gizli kelimenin her harfi için bir etiket oluştur / label: etiket
            for (int i = 0; i < game.SecretWord.Length; i++)
            {
                Label lbl = new Label();
                lbl.Text = "_"; // Alt çizgi ile başla (tahmin edilmemiş harf)
                lbl.Font = new Font("Arial", 24); // Yazı tipini ayarla
                lbl.AutoSize = true; // Etiketin otomatik boyutlandırılmasını sağla
                lbl.Margin = new Padding(5); // Etiketler arasında boşluk bırak
                flowLayoutPanel1.Controls.Add(lbl); // FlowLayoutPanel'e etiket ekle
                letterLabels.Add(lbl); // Etiketi listeye ekle
            }
        }

        // Oyun durumu ve UI güncellemeleri yapmak için metot
        private void UpdateGameUI()
        {
            pictureBoxHangman.Invalidate(); // Resmi yeniden çizerek güncelle

            // Harf etiketlerini güncelle
            for (int i = 0; i < game.SecretWord.Length; i++)
            {
                // Eğer harf tahmin edilmişse, etiketin metnini güncelle
                if (game.GuessedLetters.Contains(game.SecretWord[i]))
                {
                    letterLabels[i].Text = game.SecretWord[i].ToString(); // Doğru harfi yerleştir
                }
            }

            // Oyun durumu kontrolü ve kazanan/ kaybeden mesajı gösterimi
            if (game.IsGameWon())
            {
                MessageBox.Show("Kazandınız!");
            }
            else if (game.IsGameOver())
            {
                MessageBox.Show("Kaybettiniz! Kelime: " + game.SecretWord);
            }
        }

        private void pictureBoxHangman_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // Çizim için Graphics nesnesi
            Pen pen = new Pen(Color.Purple, 2); // Kalem rengi ve kalınlığı

            int remainingAttempts = game.RemainingAttempts; // Kalan tahmin hakkını al

            // Kalan tahmin haklarına göre adamın parçalarını çiz
            if (remainingAttempts <= 5)
            {
                // Kafayı çiz
                g.DrawEllipse(pen, 70, 20, 60, 60);
            }
            if (remainingAttempts <= 4)
            {
                // Gövdeyi çiz
                g.DrawLine(pen, 100, 80, 100, 160);
            }
            if (remainingAttempts <= 3)
            {
                // Sol kolu çiz
                g.DrawLine(pen, 100, 100, 50, 130);
            }
            if (remainingAttempts <= 2)
            {
                // Sağ kolu çiz
                g.DrawLine(pen, 100, 100, 150, 130);
            }
            if (remainingAttempts <= 1)
            {
                // Sol bacağı çiz
                g.DrawLine(pen, 100, 160, 50, 200);
            }
            if (remainingAttempts <= 0)
            {
                // Sağ bacağı çiz
                g.DrawLine(pen, 100, 160, 150, 200);
            }

            pen.Dispose(); // Kalemi serbest bırak
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            char guessedLetter;

            // Kullanıcının metin kutusundan bir harf al
            if (char.TryParse(textBox1.Text, out guessedLetter))
            {
                bool isCorrectGuess = game.Guess(guessedLetter); // Oyuna harfi ilet

                if (!isCorrectGuess)
                {
                    pictureBoxHangman.Invalidate(); // Her yanlış tahminde resmi güncelle
                }

                UpdateGameUI(); // UI'yi güncelle
            }

            textBox1.Clear(); // Metin kutusunu temizle
        }



        // Metin kutusundaki değişiklikleri izlemek için olay metodu
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Metin kutusu değişikliklerine tepki ver
            // Buraya ek işlemler yapılabilir (örneğin, sadece bir karakter girişi gibi)
        }
    }
}
