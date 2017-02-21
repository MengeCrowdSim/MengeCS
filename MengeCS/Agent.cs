using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MengeCS
{
    /// <summary>
    /// Wrapper class for a Menge::Agents::BaseAgent.
    /// </summary>
    public class Agent
    {
        internal Agent()
        {
            _pos = new Vector3();
            _vel = new Vector3();
            _orient = new Vector2();
            _class = 0;
        }

        public Vector3 Position { get { return _pos; } }
        internal Vector3 _pos;

        public Vector3 Velocity { get { return _vel; } }
        internal Vector3 _vel;

        public Vector2 Orientation { get { return _orient; } }
        internal Vector2 _orient;

        public int Class { get { return _class; } }
        internal int _class;

        public float Radius { get { return _radius; } }
        internal float _radius;
    }
}
