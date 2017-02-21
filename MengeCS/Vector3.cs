using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MengeCS
{
    public class Vector3
    {
        /// <summary>
        /// The zero construtor; creates a zero-valued 3D vector.
        /// </summary>
        public Vector3()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }

        /// <summary>
        /// Initializes the 3D vector with the given values.
        /// </summary>
        /// <param name="x">The x-value.</param>
        /// <param name="y">The y-value.</param>
        /// <param name="z">The z-value.</param>
        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// Sets the value of this vector from another.
        /// </summary>
        /// <param name="v">The vector to copy.</param>
        public void Set(Vector3 v)
        {
            _x = v._x;
            _y = v._y;
            _z = v._z;
        }

        /// <summary>
        /// Sets the values of this vector from copponents.
        /// </summary>
        /// <param name="x">The x-value.</param>
        /// <param name="y">The y-value.</param>
        /// <param name="z">The z-value.</param>
        public void Set(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public float Z
        {
            get { return _z; }
            set { _z = value; }
        }

        private float _x;
        private float _y;
        private float _z;
    }
}
