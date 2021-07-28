using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Route
{
    class Junction : Node
    {

        //private map rule<int, string>;  // key = the number of the rule, value = the name of the rule
        private DrivingDirectionSign directionSign;

        public Junction(string name,TrafficRec area,int rule):base(area,rule,name)
        {

        }

        public Junction(string name, Bounds bounds, int rule) : base(name, bounds, rule)
        {

        }

        public DrivingDirectionSign DirectionSign { get => directionSign; set => directionSign = value; }

        /*
public float RotationBottomLimit { get => rotationBottomLimit; set => rotationBottomLimit = value; }
public float RotationUpperLimit { get => rotationUpperLimit; set => rotationUpperLimit = value; }
*/
        public override bool CheckRule(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
