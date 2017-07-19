using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes
{
    public class Vector3d
    {
        public float X;
        public float Y;
        public float Z;
        public Vector3d (float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Z: +1
        /// </summary>
        static public Vector3d Up { get { return new Vector3d(0f, 0f, 1f); } }

        /// <summary>
        /// X: +1
        /// </summary>
        static public Vector3d Forward { get { return new Vector3d(1f, 0f, 0f); } }

        /// <summary>
        /// Y: +1
        /// </summary>
        static public Vector3d Side { get { return new Vector3d(0f, 1f, 0f); } }

        static public Vector3d One { get { return new Vector3d(1f, 1f, 1f); } }

        
        public static Vector3d operator * (Vector3d left, float right)
        {
            return new Vector3d(left.X * right, left.Y * right, left.Z * right);
        }
        
    }
}
