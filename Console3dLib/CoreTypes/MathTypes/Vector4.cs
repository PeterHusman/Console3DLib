using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes
{
    public class Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        public Vector4 (float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Z: +1
        /// </summary>
        static public Vector4 Up { get { return new Vector4(0f, 0f, 1f, 0f); } }

        /// <summary>
        /// X: +1
        /// </summary>
        static public Vector4 Forward { get { return new Vector4(1f, 0f, 0f, 0f); } }

        /// <summary>
        /// Y: +1
        /// </summary>
        static public Vector4 Side { get { return new Vector4(0f, 1f, 0f, 0f); } }

        /// <summary>
        /// Z: +1
        /// </summary>
        static public Vector4 WDimension { get { return new Vector4(0f, 0f, 0f, 1f); } }

        static public Vector4 One { get { return new Vector4(1f, 1f, 1f, 1f); } }

        
        public static Vector4 operator * (Vector4 left, float right)
        {
            return new Vector4(left.X * right, left.Y * right, left.Z * right, left.W * right);
        }

        public static Vector4 operator +(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }

        public static Vector4 operator -(Vector4 left, Vector4 right)
        {
            return left + right * -1f;
        }

    }
}
