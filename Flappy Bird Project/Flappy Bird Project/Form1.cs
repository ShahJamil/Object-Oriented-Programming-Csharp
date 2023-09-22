using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Project
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PipeTop_Click(object sender, EventArgs e)
        {

        }

        private void PipeBottom_Click(object sender, EventArgs e)
        {

        }

        private void Ground_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            PipeBottom.Left -= pipeSpeed;
            PipeTop.Left -= pipeSpeed;
            scoreText.Text = $"Score: {score}";
            Random random = new Random();

            if (PipeBottom.Left < -150)
            {
                PipeBottom.Left = 700;
                score++;
                scoreText.Text = score.ToString();
            }

            if (PipeTop.Left < -180)
            {
                PipeTop.Left = 650;
                
                
                score++;
                scoreText.Text = score.ToString();
            }

            if (FlappyBird.Bounds.IntersectsWith(PipeBottom.Bounds) || FlappyBird.Bounds.IntersectsWith(PipeTop.Bounds) || FlappyBird.Bounds.IntersectsWith(Ground.Bounds))
            {
                endGame();
            }


            if (score > 5)
            {
                pipeSpeed = -15;
            }
        }

        private void GameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }


        private void GameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over.";
        }
    }
}
