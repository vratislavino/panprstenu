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
            instakill.Setup("InstaKill", 5000, 30);
            doublepoints.Setup("DoublePoints", 5000, 20);
            immortality.Setup("Immortality", 2000, 50);

            instakill.BuffRequested += OnBuffRequested;
            doublepoints.BuffRequested += OnBuffRequested;
            immortality.BuffRequested += OnBuffRequested;
        }

        private void OnBuffRequested(Buff buff) {
            if(Score >= buff.Price) {
                Score -= buff.Price;
                buff.Activate();
            }
        }
    }
}
