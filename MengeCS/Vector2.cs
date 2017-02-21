using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MengeCS
{
    public class Vector2
    {
        /// <summary>
        /// The zero construtor; creates a zero-valued 2D vector.
        /// </summary>
        public Vector2()
        {
            _x = 0;
            _y = 0;
        }

        /// <summary>
        /// Initializes the 2D vector with the given values.
        /// </summary>
        /// <param name="x">The x-value.</param>
        /// <param name="y">The y-value.</param>
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Sets the value of this vector from another.
        /// </summary>
        /// <param name="v">The vector to copy.</param>
        public void Set(Vector2 v)
        {
            _x = v._x;
            _y = v._y;
        }

        /// <summary>
        /// Sets the value of this vector from components.
        /// </summary>
        /// <param name="x">The x-value.</param>
        /// <param name="y">The y-value.</param>
        public void Set(float x, float y)
        {
            _x = x;
            _y = y;
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

        private float _x;
        private float _y;
    }
}
