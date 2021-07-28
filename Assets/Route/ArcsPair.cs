using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Route
{
    class ArcsPair
    {
        private int pairID;
        private Arc arcSource;
        private Arc arcDestination;
        private DrivingDirectionSign directionSign;

        public ArcsPair(int pairID, Arc arcSource, Arc arcDestination, DrivingDirectionSign directionSign)
        {
            this.pairID = pairID;
            this.arcSource = arcSource;
            this.arcDestination = arcDestination;
            this.directionSign = directionSign;
        }

        public Arc getArcSource()
        { return this.arcSource; }

        public Arc getArcDestination()
        { return this.arcDestination; }

        public DrivingDirectionSign getDirectionSign()
        { return this.directionSign; }

    }
}