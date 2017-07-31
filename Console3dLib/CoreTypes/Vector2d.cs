using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes
{
    public class Vector2d
    {
        public float X;
        public float Y;
    
        public Vector2d(float x, float y)
        {
            X = x;
            Y = y;
           
        }



        public static Vector2d operator *(Vector2d left, float right)
        {
            return new Vector2d(left.X * right, left.Y * right);
        }

    }
}
