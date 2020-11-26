using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanPrstenuDveVeze
{
    /*
     TODO:
        Používání buffů
        ----
     */


    public partial class Canvas : UserControl {
        public event Action<int> TowerDestroyedStone;

        List<IDrawable> drawables = new List<IDrawable>();

        List<Tower> towers = new List<Tower>();
        List<Spawner> spawners = new List<Spawner>();
        List<Stone> stones = new List<Stone>();

        Tower movingTower = null;

        Random random = new Random();

        private static Canvas instance;
        public static Canvas Instance { get { return instance; } }

        public Canvas() {
            InitializeComponent();
            this.DoubleBuffered = true;
            PlaceNewTower();
            PlaceNewTower();
            instance = this;

            Tower q = new Tower();
            q = null;
            //-------
        }

        public void ObjectsUpdate(float interval) {
            spawners.ForEach(x => x.AddTime(interval));
            for (int i = 0; i < stones.Count; i++) {
                stones[i].Move();
            }
            //stones.ForEach(x => x.Move());
            towers.ForEach(x => x.UpdateCooldown(interval));

            CheckCollisions();

            Refresh();
        }

        private void CheckCollisions() {

            foreach (var tower in towers) {
                foreach (var stone in stones) {
                    if (tower.IsStoneInRange(stone)) {
                        if (!tower.IsDestroyingStone) {
                            tower.DestroyStone(stone);
                        }
                    }
                    if (tower.CheckTowerHit(stone)) {
                        tower.Hit(stone);
                    }
                }
            }

            for (int i = 0; i < towers.Count; i++) {
                towers[i].ClearDestroyedTower();
            }
            towers.ForEach(x => x.CommitDie());
        }

        public void AddSpawner(Spawner spawner) {
            spawners.Add(spawner);
        }

        public void AddStone(Stone stone) {
            stones.Add(stone);
            //Console.WriteLine(stones.Count);
            drawables.Add(stone);
            Refresh();
        }

        public bool PlaceNewTower() {
            Tower t = new Tower();
            int iterations = 100;

            while (iterations > 0) {
                int x = random.Next(t.Size.Width / 2, Width - t.Size.Width / 2);
                int y = random.Next(t.Size.Height / 2, Height / 2 - t.Size.Height / 2);
                bool isFarEnough = true;
                foreach (var tow in towers) {
                    if (tow.Position.Distance(new Point(x, y)) < Tower.MaxRange) {
                        isFarEnough = false;
                        break;
                    }
                }

                if (isFarEnough) {
                    t.Position = new Point(x, y);
                    towers.Add(t);
                    t.StoneDestroyed += OnStoneDestroyed;
                    t.TowerDestroyed += OnTowerDestroyed;
                    drawables.Add(t);
                    Refresh();
                    return true;
                } else {
                    iterations--;
                }
            }
            return false;
        }

        private void OnTowerDestroyed(Tower tower) {
            towers.Remove(tower);
            drawables.Remove(tower);
        }

        public void DestroyStone(Stone stone) {
            stones.Remove(stone);
            drawables.Remove(stone);
        }

        private void OnStoneDestroyed(Tower tower, Stone stone) {
            DestroyStone(stone);
            tower.Xp++;
            TowerDestroyedStone?.Invoke(1);
            Refresh();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e) {
            drawables.ForEach(x => x.Draw(e.Graphics));
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e) {
            Tower t = GetTowerUnderMouse(e.Location);
            if(t != null) {
                movingTower = t;
            }
        }

        private Tower GetTowerUnderMouse(Point mouse) {
            foreach (var tower in towers) {
                if(tower.CheckTowerHit(mouse)) {
                    return tower;
                }
            }
            return null;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e) {
            movingTower = null;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e) {
            if(movingTower != null) {
                movingTower.Move(e.Location);
            }
        }
    }
}
