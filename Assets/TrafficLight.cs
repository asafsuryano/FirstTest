using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Route;

namespace Assets
{
    public class TrafficLight
    {
        private int id;
        private int state; // 0- red , 1 - red and yellow, 2 - green , 3 - yellow
        private int timeInRed;
        private int timeInRedAndYellow;
        private int timeInGreen;
        private int timeInYellow;
        private int baseTime;
        private int currentTime;
        private string roadNameConnectedTo;

        public TrafficLight(int id,int timeInRed, int timeInRedAndYellow, int timeInGreen, int timeInYellow,string roadName)
        {
            this.id = id;
            this.state = 0;
            this.timeInRed = timeInRed;
            this.timeInRedAndYellow = timeInRedAndYellow;
            this.timeInGreen = timeInGreen;
            this.timeInYellow = timeInYellow;
            this.baseTime = (int)Time.time;
            this.currentTime = (int)Time.time;
            this.roadNameConnectedTo = roadName;
        }
        public TrafficLight(int id, int state,int timeInRed, int timeInRedAndYellow, int timeInGreen, int timeInYellow, string roadName)
        {
            this.id = id;
            this.state = state;
            this.timeInRed = timeInRed;
            this.timeInRedAndYellow = timeInRedAndYellow;
            this.timeInGreen = timeInGreen;
            this.timeInYellow = timeInYellow;
            this.baseTime = (int)Time.time;
            this.currentTime = (int)Time.time;
            this.roadNameConnectedTo = roadName;
        }

        public int State { get => state; set => state = value; }
        public int Id { get => id; set => id = value; }
        internal string RoadNameConnectedTo { get => roadNameConnectedTo; set => roadNameConnectedTo = value; }

        public void CheckAndChangeState()
        {
            this.currentTime = (int)Time.time;
            //Debug.Log(this.currentTime);
            if (this.currentTime - this.baseTime == this.timeInRed && this.state == 0)
            {
                this.state = (this.state + 1) % 4;
                this.baseTime = this.currentTime;
            }
            else if (this.currentTime - this.baseTime == this.timeInRedAndYellow && this.state == 1)
            {
                this.state = (this.state + 1) % 4;
                this.baseTime = this.currentTime;
            }
            else if (this.currentTime - this.baseTime == this.timeInGreen && this.state == 2)
            {
                this.state = (this.state + 1) % 4;
                this.baseTime = this.currentTime;
            }
            else if (this.currentTime - this.baseTime == this.timeInYellow && this.state == 3)
            {
                this.state = (this.state + 1) % 4;
                this.baseTime = this.currentTime;
            }
        }
        bool checkNodeCameFrom(Node nodeCameFrom)
        {
            return nodeCameFrom.Name == this.roadNameConnectedTo;
        }
    }
}
