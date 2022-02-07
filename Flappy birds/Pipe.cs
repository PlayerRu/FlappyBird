using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_birds
{
    class Pipe
    {
        float x;
        float y;
        float windowsSize;

        Image spritetop;
        Image spritebottom;

        int spriteSizeX;
        int spriteSizeY;

        bool passed;

        public float X { get => x; }
        public float Y { get => y; }
        public float WindowsSize { get => windowsSize; }
        public Image SpriteTop { get => spritetop; }
        public Image SpriteBotton { get => spritebottom; }

        public int SpriteSizeX { get => spriteSizeX; }
        public int SpriteSizeY { get => spriteSizeY; }
        public bool Passed { get => passed; set { passed = value; } }

        public Pipe(float x,float y)
        {
            spritebottom = new Bitmap("image//pipeBottom.png");
            spritetop = new Bitmap("image//pipeBottom.png");
            spritetop.RotateFlip(RotateFlipType.Rotate180FlipX);

            this.x = x;
            this.y = y;

            spriteSizeX = 45;
            spriteSizeY = 350;
            windowsSize = 150;
            passed = false;
        }
        public void Move()
        {
            x -= 2;
        }
    }
}
