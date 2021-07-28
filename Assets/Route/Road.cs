using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Route
{
    public class Road : Node
    {
        private float velocityLimitSize;
        private double[] velocityLimit;
        private double rotationDirectionLower;
        private double rotationDirectionUpper;
        private List<Junction> junctionConnected;
        private List<Road> roadsConnected;
        private Vector3 direction;

        public float VelocityLimitSize { get => velocityLimitSize; set => velocityLimitSize = value; }
        public Vector3 Direction { get => direction; set => direction = value; }

        public Road(string name,TrafficRec roadLimits,int rule,double velocityLimitX, double velocityLimitY,double velocityLimitZ,
            double rotationDirectionLower, double rotationDirectionUpper) : base(roadLimits,rule,name)
        {
            this.velocityLimit = new double[3];
            this.velocityLimit[0] = velocityLimitX;
            this.velocityLimit[1] = velocityLimitY;
            this.velocityLimit[2] = velocityLimitZ;
            this.rotationDirectionLower = rotationDirectionLower;
            this.rotationDirectionUpper = rotationDirectionUpper;
            this.junctionConnected = new List<Junction>();
            this.roadsConnected = new List<Road>();
        }

        public Road(string name, Bounds bounds, int rule, float velocityLimit
            , double rotationDirectionLower, double rotationDirectionUpper) : base(name, bounds, rule)
        {
            this.velocityLimitSize = velocityLimit;
            this.rotationDirectionLower = rotationDirectionLower;
            this.rotationDirectionUpper = rotationDirectionUpper;
            this.junctionConnected = new List<Junction>();
            this.roadsConnected = new List<Road>();
        }

        public Road(string name, Bounds bounds, int rule, float velocityLimit
                ,float directionX,float directionY,float directionZ) : base(name, bounds, rule)
        {
            this.velocityLimitSize = velocityLimit;
            this.junctionConnected = new List<Junction>();
            this.roadsConnected = new List<Road>();
            this.direction = new Vector3(directionX, directionY, directionZ);
        }

        public override bool CheckRule(Car car)
        {
            throw new NotImplementedException();
        }

        public bool CheckVelocityLimit(double[] carVelocity)
        {
            if ((carVelocity[0]<=this.velocityLimit[0]) &&
                    (carVelocity[1]<=this.velocityLimit[1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
