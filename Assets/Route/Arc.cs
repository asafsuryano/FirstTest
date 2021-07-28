using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Route
{
    class Arc
    {
        private int arcID;
        private Node source;
        private Node destination;
        private int ruleID;

        internal int ArcID { get => arcID; set => arcID = value; }
        internal Node Source { get => source; set => source = value; }
        internal Node Destination { get => destination; set => destination = value; }
        internal int RuleID { get => ruleID; set => ruleID = value; }

        public Arc(int arcID, Node source, Node destination, int ruleID)
        {
            this.arcID = arcID;
            this.source = source;
            this.destination = destination;
            this.ruleID = ruleID;
        }

        public Arc ()
        {
            this.source = null;
            this.destination = null;
        }

    }
}
