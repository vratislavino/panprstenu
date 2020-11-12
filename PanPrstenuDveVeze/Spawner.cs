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

        private float rate = 0.5f; // in seconds
        private float currentTime;

        private Point position;

        private float minAngle;
        private float maxAngle;

        private Random random;

        public Spawner(Point position, float rate, float minAngle, float maxAngle) {
            random = new Random();
            this.position = position;
            this.rate = rate;
            this.minAngle = minAngle;
            this.maxAngle = maxAngle;
            currentTime = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time">Time in seconds</param>
        public void AddTime(float time) {
            currentTime += time;
            if(currentTime > rate) {
                CreateObject();
                currentTime -= rate;
            }
        }
        
        private void CreateObject() {
            Stone s = new Stone(random.Next((int)minAngle, (int)maxAngle), 4, position);
            StoneCreated?.Invoke(s);
        }

    }
}
