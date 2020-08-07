using System;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class FlappBird : Form
    {

        int pipeSpeed = 8;
        int gravity = 4;
        int score = 0;        
        public FlappBird()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            pipeTop2.Left -= pipeSpeed;
            pipeBottom2.Left -= pipeSpeed;

            if (pipeBottom.Left < -120)
            {
                pipeBottom.Left = 700;
                score++;
                labelScore.Text = "Score: " + score.ToString();
            }
            if (pipeTop.Left < -120)
            {
                pipeTop.Left = 750;
            }
            if (pipeBottom2.Left < -120)
            {
                pipeBottom2.Left = 1400;
                score++;
                labelScore.Text = "Score: " + score.ToString();
            }
            if (pipeTop2.Left < -120)
            {
                pipeTop2.Left = 700;
            }

            // Collision detection
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                   flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                   flappyBird.Bounds.IntersectsWith(ground.Bounds)  ||
                   flappyBird.Top < 0)
            {
                endGame();
            }

        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -13; 
            }
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = +5;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            labelScore.Text += " Game Over";
            
        }
    }
}
