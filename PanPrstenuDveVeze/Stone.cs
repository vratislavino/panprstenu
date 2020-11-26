using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanPrstenuDveVeze
{
    public class Stone : IDrawable
    {
        private float angle;
        private float speed;

        private float size = 8;

        private float posX, posY;
        private Point position;

        public Point Position {
            get { return position; }
        }

        public Stone(float angle, float speed, Point position) {
            this.angle = angle;
            this.speed = speed;
            this.position = position;
            posX = position.X;
            posY = position.Y;
        }

        public void Move() {
            float x = (float) (posX + Math.Cos(ToRad(angle)) * speed);
            float y = (float) (posY + Math.Sin(ToRad(angle)) * speed);

            posX = x;
            posY = y;

            position = new Point((int)posX, (int)posY);

            // jestli je stone mimo hranice canvasu
            if(position.X < 0 
                || position.X > Canvas.Instance.Width 
                || position.Y < 0 
                || position.Y > Canvas.Instance.Height) {
                Canvas.Instance.DestroyStone(this);
            }
        }

        private double ToRad(float deg) {
            return (Math.PI / 180) * deg;
        }

        public void Draw(Graphics g) {
            g.FillEllipse(Brushes.Black, position.X-size/2, position.Y-size/2, size, size);
        }

    }
}
