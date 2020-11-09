using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace PanPrstenuDveVeze
{
    public class Tower
    {
        public int Xp {
            get { return xp; }
            set {
                xp = value;
                
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

        private Point position;
        private Size size;
        private int level;
        private int hp;
        private int xp;
        private int xpNeeded;

        private float currentRange;

        public Tower() {
            currentRange = BASE_RANGE;
            xpNeeded = 3;
        }

        public void Draw(Graphics g) {

        }

        public void Move(Point pos) {

        }
    }
}
