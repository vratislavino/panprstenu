using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanPrstenuDveVeze
{
    public partial class Form1 : Form
    {
        int score = 40;
        public int Score {
            get { return score; }
            private set {
                score = value;
                scoreLabel.Text = "Score: " + score;
            }
        }

        public Form1() {
            InitializeComponent();
            Score = 100;
            InitBuffs();
            Spawner sp = new Spawner(new Point(0, canvas1.Height), 0.1f, 270, 360);
            Spawner sp2 = new Spawner(new Point(canvas1.Width, canvas1.Height), 0.1f, 180, 270);

            canvas1.TowerDestroyedStone += OnTowerDestroyedStone;

            canvas1.AddSpawner(sp);
            canvas1.AddSpawner(sp2);
            sp.StoneCreated += canvas1.AddStone;
            sp2.StoneCreated += canvas1.AddStone;
        }

        private void OnTowerDestroyedStone(int pointsCount) {
            Score += doublepoints.IsActive ? 2 * pointsCount : pointsCount;
        }

        private void InitBuffs() {
            instakill.Setup("InstaKill", 5000, 30);
            doublepoints.Setup("DoublePoints", 5000, 20);
            immortality.Setup("Immortality", 2000, 50);

            instakill.BuffRequested += OnBuffRequested;
            doublepoints.BuffRequested += OnBuffRequested;
            immortality.BuffRequested += OnBuffRequested;
        }

        private void OnBuffRequested(Buff buff) {
            if (Score >= buff.Price) {
                Score -= buff.Price;
                buff.Activate();
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e) {
            canvas1.ObjectsUpdate(gameTimer.Interval / 1000f);
        }
    }
}
