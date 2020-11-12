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
    public partial class Canvas : UserControl
    {
        List<IDrawable> drawables = new List<IDrawable>();

        List<Tower> towers = new List<Tower>();
        List<Spawner> spawners = new List<Spawner>();
        List<Stone> stones = new List<Stone>();

        Random random = new Random();

        public Canvas() {
            InitializeComponent();
            this.DoubleBuffered = true;
            PlaceNewTower();
            PlaceNewTower();
        }

        public void ObjectsUpdate(float interval) {
            spawners.ForEach(x => x.AddTime(interval));
            stones.ForEach(x => x.Move());
            Refresh();
        }

        public void AddSpawner(Spawner spawner) {
            spawners.Add(spawner);
        }

        public void AddStone(Stone stone) {
            stones.Add(stone);
            Console.WriteLine(stones.Count);
            drawables.Add(stone);
            Refresh();
        }

        public void PlaceNewTower() {
            Tower t = new Tower();

            while (true) {
                int x = random.Next(t.Size.Width / 2, Width - t.Size.Width / 2);
                int y = random.Next(t.Size.Height / 2, Height / 2 - t.Size.Height / 2);
                bool isFarEnough = true;
                foreach(var tow in towers) {
                    if(tow.Position.Distance(new Point(x,y)) < Tower.MaxRange) {
                        isFarEnough = false;
                        break;
                    }
                }

                if(isFarEnough) {
                    t.Position = new Point(x, y);
                    towers.Add(t);
                    drawables.Add(t);
                    Refresh();
                    break;
                }
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e) {
            drawables.ForEach(x => x.Draw(e.Graphics));
        }
    }
}
