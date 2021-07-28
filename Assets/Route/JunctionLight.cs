using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Route
{
    class JunctionLight : Junction
    {
        private List<TrafficLight> lights;

        public JunctionLight(string name,TrafficRec area, int rule) : base(name,area, rule)
        {
            this.lights = new List<TrafficLight>();
        }

        public JunctionLight(string name, Bounds bound, int rule) : base(name, bound, rule)
        {
            this.lights = new List<TrafficLight>();
        }

        public void AddTrafficLight(TrafficLight light)
        {
            this.lights.Add(light);
        }

        public bool IsDrivingAccordingToLights(Road roadCameFrom)
        {
            for (int i = 0; i < this.lights.Count; i++)
            {
                if (this.lights[i].RoadNameConnectedTo==roadCameFrom.Name)
                {
                    if (this.lights[i].State==2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

    }
}
