using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes
{
    public class Vector2
    {
        public float X;
        public float Y;
    
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
           
        }



        public static Vector2 operator *(Vector2 left, float right)
        {
            return new Vector2(left.X * right, left.Y * right);
        }

    }
}
