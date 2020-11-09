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

        private float size;

        private Point position;

        public void Move() {
            // TODO MOVE
        }

        public void Draw(Graphics g) {
            g.FillEllipse(Brushes.Black, position.X-size/2, position.Y-size/2, size, size);
        }

    }
}
