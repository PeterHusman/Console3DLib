using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes
{
    public class Vector4d
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        public Vector4d (float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Z: +1
        /// </summary>
        static public Vector4d Up { get { return new Vector4d(0f, 0f, 1f, 0f); } }

        /// <summary>
        /// X: +1
        /// </summary>
        static public Vector4d Forward { get { return new Vector4d(1f, 0f, 0f, 0f); } }

        /// <summary>
        /// Y: +1
        /// </summary>
        static public Vector4d Side { get { return new Vector4d(0f, 1f, 0f, 0f); } }

        /// <summary>
        /// Z: +1
        /// </summary>
        static public Vector4d WDimension { get { return new Vector4d(0f, 0f, 0f, 1f); } }

        static public Vector4d One { get { return new Vector4d(1f, 1f, 1f, 1f); } }

        
        public static Vector4d operator * (Vector4d left, float right)
        {
            return new Vector4d(left.X * right, left.Y * right, left.Z * right, left.W * right);
        }
        
    }
}
