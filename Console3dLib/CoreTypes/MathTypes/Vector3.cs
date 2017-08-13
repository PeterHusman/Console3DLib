using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes
{
    public class Vector3
    {
        public float X;
        public float Y;
        public float Z;
        public Vector3 (float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Z: +1
        /// </summary>
        static public Vector3 Up { get { return new Vector3(0f, 0f, 1f); } }

        /// <summary>
        /// X: +1
        /// </summary>
        static public Vector3 Forward { get { return new Vector3(1f, 0f, 0f); } }

        /// <summary>
        /// Y: +1
        /// </summary>
        static public Vector3 Side { get { return new Vector3(0f, 1f, 0f); } }

        static public Vector3 One { get { return new Vector3(1f, 1f, 1f); } }

        
        public static Vector3 operator * (Vector3 left, float right)
        {
            return new Vector3(left.X * right, left.Y * right, left.Z * right);
        }

        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return left + right * -1f;
        }

    }
}
