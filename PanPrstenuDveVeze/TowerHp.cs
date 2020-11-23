using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanPrstenuDveVeze
{
    public class TowerHp
    {
        public event Action TowerDestroyed;

        public int maxHP;
        private int currentHp;

        public int CurrentHp {
            get { return currentHp; }
            set {
                currentHp = value;
                if(currentHp <= 0) {
                    TowerDestroyed?.Invoke();
                }
            }
        }

        public TowerHp(int maxHp) {
            this.maxHP = maxHp;
            this.currentHp = maxHp;
        }

        public void Draw(Graphics g, Point position, Size size) {

            g.FillPie(Brushes.Green,
                position.X - size.Width / 2 + 1,
                position.Y - size.Height / 2 + 1,
                size.Width - 2,
                size.Height - 2, 
                270,
                ((float)currentHp / maxHP) * 360
                );
        
        }

    }
}
