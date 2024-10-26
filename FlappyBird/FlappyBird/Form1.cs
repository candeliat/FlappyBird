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
    public partial class Form1 : Form
    {

        int pipeSpeed = 8; 
        int gravity = 15;
        int score = 0; 
        

        public Form1()
        {
            InitializeComponent();
            gameTimer.Stop();
        }
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            // Boşluk tuşu ile kontrol etme
            if (e.KeyCode == Keys.Space)
            {
               
                gravity = -15;
            }


        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            // Boşluk tuşu ile kontrol etme

            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
                
            }

        }

        private void endGame()
        {
            // Oyunu durdurma fonksiyonu, duvara veya yere değdiğinde durur. 
            gameTimer.Stop(); // zaman durdurucu
            scoreText.Text += " Game over!!!"; 
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity; 
            pipeBottom.Left -= pipeSpeed; 
            pipeTop.Left -= pipeSpeed; 
            scoreText.Text = "Score: " + score; 

            

            if (pipeBottom.Left < -150)
            {
                // Eğer alt boruların konumu -150 ise, konumunu 800 yapacak ve puana 1 ekleyeceğiz.
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                // Eğer üst boruların konumu -180 ise, boruyu 950 yapacak ve puana 1 ekleyeceğiz.
                pipeTop.Left = 950;
                score++;
            }

            // Aşağıdaki if ifadesi, borunun yere çarpıp çarpmadığını, borulara çarpıp çarpmadığını veya oyuncunun ekranın üstünden çıkıp çıkmadığını kontrol ediyor

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {
                // Yukarıdaki koşullardan herhangi biri sağlanırsa, oyun sonlandırma fonksiyonunu çalıştıracağız.
                endGame();
            }


            // Eğer puan 5'ten büyükse, boru hızını 15'e çıkaracağız.
            if (score > 5)
            {
                pipeSpeed = 15;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startGame();
        }
        private void startGame()
        {
            score = 0; // Skor sıfırlanır
            gravity = 15; // Varsayılan gravity ayarlanır
            pipeSpeed = 8; // Varsayılan pipeSpeed ayarlanır

            // Boruları ve kuşu başlangıç pozisyonuna getirin
            flappyBird.Top = 200;
            pipeBottom.Left = 800;
            pipeTop.Left = 950;

            gameTimer.Start(); // Timer başlatılır
            startButton.Enabled = false; // Başlama butonu devre dışı bırakılır
        }
        

       
    }
}
