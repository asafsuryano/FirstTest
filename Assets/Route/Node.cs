using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Route
{
    public abstract class Node
    {
        private TrafficRec areaOfEffect; //to calculate the area we need to use 'transform.localscale'
        private Bounds nodeBounds;
        private int rule;
        private DrivingDirectionSign directionSign;
        private string name;
        private List<Arc> edgesFrom;
        private List<Arc> edgesTo;

        public Node(TrafficRec area, int rule, string name)
        {
            this.name = name;
            this.areaOfEffect = area;
            this.rule = rule;
        }

        public Node(string name, Bounds nodeBounds, int rule)
        {
            this.nodeBounds = nodeBounds;
            this.rule = rule;
            this.name = name;
            this.edgesFrom = new List<Arc>();
            this.edgesTo = new List<Arc>();
        }

        public int Rule { get => rule; set => rule = value; }
        public TrafficRec AreaOfEffect { get => areaOfEffect; set => areaOfEffect = value; }
        public Bounds NodeBounds { get => nodeBounds; set => nodeBounds = value; }
        public string Name { get => name; set => name = value; }
        internal List<Arc> EdgesFrom { get => edgesFrom; set => edgesFrom = value; }

        public abstract bool CheckRule(Car car);

        public void setDirectionSign(DrivingDirectionSign directionSign)
        {
            this.directionSign = directionSign;
        }

        public DrivingDirectionSign getDirectionSign()
        {
            return this.directionSign;
        }

        //public void AddEdgeFrom(Node nodeDestination)
        //{
        //    ArcDirection arc = new ArcDirection(this, nodeDestination);
        //    this.edgesFrom.Add(arc);
        //}

        // implementation choices
        //1. work with a lot of ifs to make sure that even if the cube rotates it will still calculate correctly
        //2. use unity's engine Bounds

        // this is implementation 1
        /*
        public bool CheckPosition(Vector3 position)
        {

            if (areaOfEffect.PositionXUpperLeft <= position.x && position.x <= areaOfEffect.PositionXBottomRight)
            {
                if (areaOfEffect.PositionZBottomRight <= position.z && position.z <= areaOfEffect.PositionZUpperLeft)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        */

        //this is implementation 2
        public bool CheckPosition(Vector3 position)
        {
            if (this.nodeBounds.min.x <= position.x 
                && position.x <= this.nodeBounds.max.x
                && this.nodeBounds.min.z <= position.z 
                && position.z <= this.nodeBounds.max.z)
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
