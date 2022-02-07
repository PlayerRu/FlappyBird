using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_birds
{
    class Bird
    {
        double x;
        double y;

        Image sprite;
        SoundPlayer jumpSound;
        int spriteSize;

        double fallingSpeed;

        public double X { get => x; }
        public double Y { get => y; }
        public Image Sprite { get => sprite; }
        public int SpriteSize { get => spriteSize; }
        public SoundPlayer JumpSound { get => jumpSound; }
        public double FallingSpeed { get => fallingSpeed; }

        public Bird(double x, double y)
        {
            sprite = Image.FromFile("image//bird.png");
            jumpSound = new SoundPlayer("audio//fly.way");
            this.x = x;
            this.y = y;
            spriteSize = 30;
            fallingSpeed = 0.1f;

        }
        public void jump()
        {
            this.fallingSpeed = -7f;
        }
        public void fall(float gravity)
        {
            this.fallingSpeed += gravity;
            this.y += fallingSpeed;
        }
    }
}
