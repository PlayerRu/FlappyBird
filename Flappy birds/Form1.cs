using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_birds
{
    public partial class f_FlappyBird : Form
    {
        int score;

        Bird bird;
        Pipe pipe1;
        Pipe pipe2;

        float pipeShift;
        float gravityValue;

        bool gameOver;
        private void init()
        {
            gameOver = false;

            gravityValue = 0.3f;
            pipeShift = 206;
            score = 0;

            bird = new Bird(50, 206);
            pipe1 = new Pipe(300, -pipeShift);
            pipe2 = new Pipe(600, -pipeShift);
        }

        private void CreateWall()
        {
            Random ran = new Random();
            float newY = -pipeShift + ran.Next(-100, 100);
            if (bird.X - 300 > pipe1.X)
            {
                pipe1 = new Pipe((float)bird.X + 300, newY);

            }
            if (bird.X - 300 > pipe2.X)
            {
                pipe2 = new Pipe((float)bird.X + 300, newY);
            }
        }

        private void updateScore()
        {
            if(bird.X>pipe1.X + pipe1.SpriteSizeX&& !pipe1.Passed)
            {
                score++;
                pipe1.Passed = true;

            }
            if(bird.X>pipe2.X+pipe2.SpriteSizeX&& !pipe2.Passed)
            {
                score++;
                pipe2.Passed = true;

            }
                    
        }



        public f_FlappyBird()
        {

            InitializeComponent();
            init();

        }

        private void f_FlappyBird_Paint(object sender, PaintEventArgs e)
        {
            this.Text = $" {score} ";
            Graphics graphics = e.Graphics;
            if (!gameOver)
                graphics.DrawImage(bird.Sprite, (float)bird.X, (float)bird.Y, bird.SpriteSize, bird.SpriteSize);
            else
            {
                Image deadBird = bird.Sprite;
                deadBird.RotateFlip(RotateFlipType.Rotate180FlipX);
                graphics.DrawImage(deadBird, (float)bird.X, (float)bird.Y, bird.SpriteSize, bird.SpriteSize);
            }
            graphics.DrawImage(pipe1.SpriteTop, pipe1.X, pipe1.Y, pipe1.SpriteSizeX, pipe1.SpriteSizeY);
            graphics.DrawImage(pipe1.SpriteBotton, pipe1.X, pipe1.Y + pipe1.SpriteSizeY + pipe1.WindowsSize, pipe1.SpriteSizeX, pipe1.SpriteSizeY);

            graphics.DrawImage(pipe2.SpriteTop, pipe2.X, pipe2.Y, pipe2.SpriteSizeX, pipe2.SpriteSizeY);
            graphics.DrawImage(pipe2.SpriteBotton, pipe2.X, pipe2.Y + pipe2.SpriteSizeY + pipe2.WindowsSize, pipe2.SpriteSizeX, pipe2.SpriteSizeY);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Frame();
        }
        private void Frame()
        {

            if (!gameOver)
            {
                pipe1.Move();
                pipe2.Move();
                bird.fall(gravityValue);
                CreateWall();
                if (CheckGameOver(pipe1) || CheckGameOver(pipe2) || CheckGameOver())
                    gameOver = true;
                
                Invalidate();
                updateScore();
            }
            else
            {
                timer1.Stop();
            }
        }
        private bool CheckGameOver()
        {
            if (bird.Y > 500)
                return true;
            else
                return false;

            
        }
        
        private bool CheckGameOver(Pipe pipe1)
        {
            float birdLBound = (float)bird.X;
            float birdRBound = (float)bird.X + bird.SpriteSize;
            float birdRUBound = (float)bird.Y;
            float birdBBound = (float)bird.Y + bird.SpriteSize;

            float pipesL = pipe1.X;
            float pipesR = pipe1.X + pipe1.SpriteSizeX;
            float topPipe = pipe1.Y + pipe1.SpriteSizeY;
            float bottomPipe = pipe1.Y + pipe1.SpriteSizeY + pipe1.WindowsSize;

            if(birdLBound<pipesR && birdRBound > pipesL)
            {
                if((birdRUBound<=topPipe)||(birdBBound>=bottomPipe))
                {
                    return true;

                }
                else
                {
                    return false;
                }
                      
            }
            else
            {
                return false;
            }



        }

        private void controll()
        {
            if (!gameOver)
            {
                //bird.JumpSound.Play();
                bird.jump();
            }
            else
                init();
            if(!timer1.Enabled)
            {
                timer1.Start();
                timer1.Interval = 10;
                bird.jump();
            }
        }
        private void f_FlappyBird_MouseDown(object sender, MouseEventArgs e)
        {
            controll();

        }
    }
}
