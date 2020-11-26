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
        public event Action<Tower, Stone> StoneDestroyed;
        public event Action<Tower> TowerDestroyed;

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
        private const float BASE_RANGE = 20; // 20

        public static float MaxRange = -1;

        private Point position;
        public Point Position {
            get { return position; }
            set { position = value; }
        }
        
        private Size size;
        public Size Size => size;

        public bool IsDestroyingStone { 
            get {
                return destroyCooldown > 0;
            } 
        }

        private List<Stone> destroyingStones = new List<Stone>();

        private int level;
        private TowerHp hp;
        private int xp;
        private int xpNeeded;

        private float currentRange;

        private float timeToDestoyStone = 50f;//0.3f;//0.3f;
        private float destroyCooldown = 0;

        private static Pen towerPen = new Pen(Color.Black, 3);
        private static Pen rangePen = new Pen(Color.Red, 1);

        private bool isDestroyed = false;

        public Tower() {
            if(MaxRange == -1) {
                CalculateMaxRange();
                rangePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            size = new Size(20, 20);
            currentRange = BASE_RANGE;
            xpNeeded = 3;
            hp = new TowerHp(3);
            hp.TowerDestroyed += OnTowerDestroyed;
        }

        private void OnTowerDestroyed() {
            isDestroyed = true;
        }

        public void ClearDestroyedTower() {
            if(isDestroyed)
                TowerDestroyed?.Invoke(this);
        }

        public void UpdateCooldown(float interval) {
            if(IsDestroyingStone) {
                destroyCooldown -= interval;
            }
        }

        public void DestroyStone(Stone stone) {
            destroyingStones.Add(stone);
            destroyCooldown = Form1.Instance.Instakill.IsActive ? 0 : timeToDestoyStone;
        }

        public void CommitDie() {
            if (destroyingStones.Count > 0) {
                StoneDestroyed?.Invoke(this, destroyingStones.First());
                destroyingStones.RemoveAt(0);
            }
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
            hp.Draw(g, position, size);
        }

        public bool IsStoneInRange(Stone s) {
            double dist = position.Distance(s.Position);
            return dist <= currentRange;
        }

        public bool CheckTowerHit(Stone s) {
            return CheckTowerHit(s.Position);
        }

        public bool CheckTowerHit(Point p) {
            double dist = position.Distance(p);
            return dist <= size.Width / 2;
        }

        public void Hit(Stone s) {
            if(!Form1.Instance.Immortality.IsActive)
                hp.CurrentHp--;
            destroyingStones.Add(s);
        }

        public void Move(Point pos) {
            position = pos;
        }
    }
}
