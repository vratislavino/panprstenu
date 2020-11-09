using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace PanPrstenuDveVeze
{
    public class Tower : IDrawable
    {
        public int Xp {
            get { return xp; }
            set {
                xp = value;
                if (level == MAX_LEVEL)
                    return;

                if(xp >= xpNeeded) {
                    xp -= xpNeeded;
                    level++;
                    xpNeeded =(int)(XP_MULT*xpNeeded);
                    currentRange *= RANGE_MULT;
                }
            }
        }

        private const int MAX_LEVEL = 10;
        private const float RANGE_MULT = 1.1f;
        private const float XP_MULT = 1.3f;
        private const float BASE_RANGE = 20;

        public static float MaxRange = -1;

        private Point position;
        public Point Position {
            get { return position; }
            set { position = value; }
        }
        
        private Size size;
        public Size Size => size;
        private int level;
        private int hp;
        private int xp;
        private int xpNeeded;

        private float currentRange;

        private static Pen towerPen = new Pen(Color.Black, 3);
        private static Pen rangePen = new Pen(Color.Red, 1);

        public Tower() {
            if(MaxRange == -1) {
                CalculateMaxRange();
                rangePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            size = new Size(20, 20);
            currentRange = BASE_RANGE;
            xpNeeded = 3;
        }

        private static void CalculateMaxRange() {
            float tempRange = BASE_RANGE;
            for(int i = 0; i < MAX_LEVEL; i++) {
                tempRange *= RANGE_MULT;
            }
            MaxRange = tempRange;
        }

        public void Draw(Graphics g) {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillEllipse(Brushes.Red, Position.X - size.Width / 2, Position.Y - size.Height / 2, size.Width, size.Height);
            g.DrawEllipse(towerPen, Position.X - size.Width / 2, Position.Y - size.Height / 2, size.Width, size.Height);

            g.DrawEllipse(rangePen, Position.X - currentRange, Position.Y - currentRange, 2 * currentRange, 2 * currentRange);
        }

        public void Move(Point pos) {

        }
    }
}
