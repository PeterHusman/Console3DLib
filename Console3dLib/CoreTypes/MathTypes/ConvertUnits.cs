using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes.MathTypes
{
    public static class ConvertUnits
    {
        public static float DegreesToRadians(float degrees)
        {
            return (degrees / 180) * (float)Math.PI;
        }
        public static float RadiansToDegrees(float radians)
        {
            return (radians * 180)/(float)Math.PI;
        }

        public static Vector3 DegreesToRadians(Vector3 degrees)
        {
            return new Vector3(DegreesToRadians(degrees.X), DegreesToRadians(degrees.Y), DegreesToRadians(degrees.Z));
        }
        public static Vector3 RadiansToDegrees(Vector3 radians)
        {
            return new Vector3(RadiansToDegrees(radians.X), RadiansToDegrees(radians.Y), RadiansToDegrees(radians.Z));
        }
    }
}
