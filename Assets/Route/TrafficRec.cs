using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Route
{

    public class TrafficRec
    {
        private double positionXUpperLeft;
        private double positionYUpperLeft;
        private double positionZUpperLeft;
        private double positionXBottomRight;
        private double positionYBottomRight;
        private double positionZBottomRight;

        public TrafficRec(double positionXUpperLeft, double positionYUpperLeft, double positionZUpperLeft,
            double positionXBottomRight, double positionYBottomRight, double positionZBottomRight)
        {
            this.positionXBottomRight = positionXBottomRight;
            this.positionYBottomRight = positionYBottomRight;
            this.positionZBottomRight = positionZBottomRight;
            this.positionXUpperLeft = positionXUpperLeft;
            this.positionYUpperLeft = positionYUpperLeft;
            this.positionZUpperLeft = positionZUpperLeft;

        }

        public double PositionXUpperLeft { get => positionXUpperLeft; set => positionXUpperLeft = value; }
        public double PositionYUpperLeft { get => positionYUpperLeft; set => positionYUpperLeft = value; }
        public double PositionZUpperLeft { get => positionZUpperLeft; set => positionZUpperLeft = value; }
        public double PositionXBottomRight { get => positionXBottomRight; set => positionXBottomRight = value; }
        public double PositionYBottomRight { get => positionYBottomRight; set => positionYBottomRight = value; }
        public double PositionZBottomRight { get => positionZBottomRight; set => positionZBottomRight = value; }
    }
}
