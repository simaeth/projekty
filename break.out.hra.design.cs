using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout_Game
{
    public partial class Form1 : Form
    {

        bool goLeft;
        bool goRight;
        bool isGameOver;

        int score;
        int ballx;
        int bally;
        int playerSpeed;

        Random rnd = new Random();

        PictureBox[] blockArray;

        public Form1()
        {
            InitializeComponent();

            PlaceBlocks();
        }

        private void setupGame()
        {
            isGameOver = false;
            score = 0;
            ballx = 5;
            bally = 5;
            playerSpeed = 12;
            txtScore.Text = "Skóre: " + score;

            mic.Left = 376;
            mic.Top = 328;

            hrac.Left = 347;

            gameTimer.Start();

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "blocks")
                {
                    x.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                }
            }
        }


        private void gameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();

            txtScore.Text = "Skóre: " + score + " " + message;
        }

        private void PlaceBlocks()

        {
            blockArray = new PictureBox[15];
            
            int a = 0;

            int top = 50;
            int left = 100;

            for(int i = 0; i < blockArray.Length; i++)
            {
                blockArray[i] = new PictureBox();
                blockArray[i].Height = 32;
                blockArray[i].Width = 100;
                blockArray[i].Tag = "blocks";
                blockArray[i].BackColor = Color.White;


                if(a == 5)
                {
                    top = top + 50;
                    left = 100;
                    a = 0;
                }

                if(a < 5)
                {
                    a++;
                    blockArray[i].Left = left;
                    blockArray[i].Top = top;
                    this.Controls.Add(blockArray[i]);
                    left = left + 130;
                }

            }
            setupGame();
        }

        private void removeBlocks()
        {
            foreach(PictureBox x in blockArray) 
            { 
                this.Controls.Remove(x);
            }


        }


        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Skóre: " + score;

            if(goLeft == true && hrac.Left > 0)
            {
                hrac.Left -= playerSpeed; 
            }


            if (goRight == true && hrac.Left < 700)
            {
                hrac.Left += playerSpeed;
            }

            mic.Left += ballx;
            mic.Top += bally;

            if (mic.Left < 0 || mic.Left > 775)
            {
                ballx = -ballx;
            }
            if(mic.Top < 0)
            {
                bally = -bally;
            }

            if(mic.Bounds.IntersectsWith(hrac.Bounds))
            {

                mic.Top = 463;

                bally = rnd.Next(5, 12) * -1;

                if(ballx < 0)
                {
                    ballx = rnd.Next(5,12) * -1;
                }
                else
                {
                    ballx = rnd.Next(5, 12);
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "blocks")
                {
                    if(mic.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;

                        bally = -bally;

                        this.Controls.Remove(x);
                    }
                }

            }


            if(score == 15)
            {
                //tady je zprava o konci hry 
                gameOver("Výhra! Zmáčkni Enter Pro Další Hru");
            }

            if(mic.Top > 500)
            {
                //tady je zprava o prohre
                gameOver("Prohra! Zmáčkni Enter Pro Další Hru");
            }

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                removeBlocks();
                PlaceBlocks();
            }


        }

        private void player_Click(object sender, EventArgs e)
        {
           
        }

        private void txtScore_Click(object sender, EventArgs e)
        {
            
        }
    }
}
//chci pridat dalsi levely, main menu, hudbu a zvuky kdyz mic hitne blok