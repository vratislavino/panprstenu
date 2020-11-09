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
    public partial class Buff : UserControl
    {
        public event Action<Buff> BuffRequested;

        private string name;
        private float duration;
        private int price;
        public int Price { get { return price; } }

        private bool isActive = false;
        public bool IsActive { get { return isActive; } }

        private float currentProgress = 0;


        public Buff() {
            InitializeComponent();
        }

        public void Setup(string name, float duration, int price) {
            this.name = name;
            this.duration = duration;
            this.price = price;

            button.Text = name + $"\n({price})";

            timer1.Interval = 10;
        }

        private void button_Click(object sender, EventArgs e) {
            BuffRequested?.Invoke(this);
        }

        public void Activate() {
            button.Enabled = false;
            currentProgress = 0;
            isActive = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            currentProgress += timer1.Interval;

            pictureBox1.Refresh();
            if(currentProgress >= duration) {
                isActive = false;
                button.Enabled = true;
                timer1.Stop();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            e.Graphics.FillPie(Brushes.Red, 0, 0, pictureBox1.Width, pictureBox1.Height, -90, 360-currentProgress / duration * 360);
        }
    }
}
