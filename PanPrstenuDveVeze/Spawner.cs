using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanPrstenuDveVeze
{
    public class Spawner
    {
        public event Action<Stone> StoneCreated;

        private float rate = 0.5f;
        private float currentTime;

        private Point position;

        private float minAngle;
        private float maxAngle;

        public Spawner(Point position, float rate, float minAngle, float maxAngle) {
            this.position = position;
            this.rate = rate;
            this.minAngle = minAngle;
            this.maxAngle = maxAngle;
            currentTime = 0;
        }

        public void AddTime(float time) {
            currentTime += time;
            if(currentTime > rate) {
                CreateObject();
                currentTime -= rate;
            }
        }
        
        private void CreateObject() {

        }

    }
}
