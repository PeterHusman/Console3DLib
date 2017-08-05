using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes
{
    public class Quaternion
    {
        public Vector4 Values;

        public Quaternion(Vector4 vals)
        {
            Values = vals;
        }
        public Quaternion(float x, float y, float z, float w)
        {
            Values = new Vector4(x, y, z, w);
        }
        /// <summary>
        /// Converts to quaternion from euler angles
        /// </summary>
        /// <param name="eulerAngles">Euler angles in radians</param>
        /// <returns></returns>
        public static Quaternion FromEulerAngles(Vector3 eulerAngles)
        {
            float t0 = (float)Math.Cos(eulerAngles.Y / 2);
            float t1 = (float)Math.Sin(eulerAngles.Y / 2);
            float t2 = (float)Math.Cos(eulerAngles.X/2);
            float t3 = (float)Math.Sin(eulerAngles.X/2);
            float t4 = (float)Math.Cos(eulerAngles.Z / 2);
            float t5 = (float)Math.Sin(eulerAngles.Z / 2);


            return new Quaternion(
                t0*t3*t4-t1*t2*t5,
                t0*t2*t5+t1*t3*t4,
                t1*t2*t4-t0*t3*t5,
                t0*t2*t4+t1*t3*t5);
            
        }

        /// <summary>
        /// Radians!!!!
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Vector3 ToEulerAngles(Quaternion q)
        {
            Vector3 output = new Vector3(0,0,0);

            float Ysqr = q.Values.Y * q.Values.Y;

            float t0 = 2f * (q.Values.W * q.Values.X + q.Values.Y * q.Values.Z);
            float t1 = 1f - 2f * (q.Values.X * q.Values.X + Ysqr);
            output.X = (float)Math.Atan2(t0, t1);
           
            float t2 = 2f * (q.Values.W * q.Values.Y - q.Values.Z * q.Values.X);
            t2 = ((t2 > 1f) ? 1f : t2);
            t2 = ((t2 < -1f) ? -1f : t2);
            output.Y = (float)Math.Asin(t2);

            float t3 = 2f * (q.Values.W * q.Values.Z + q.Values.X * q.Values.Y);
            float t4 = 1f - 2f * (Ysqr + q.Values.Z * q.Values.Z);
            output.Z = (float)Math.Atan2(t3, t4);

            return output;
        }

        public static Matrix ToRotationMatrix(Quaternion q)
        {
            Matrix a = new Matrix(new float[4, 4] {
            { q.Values.W, q.Values.Z, -q.Values.Y, q.Values.X },
            { -q.Values.Z, q.Values.W, q.Values.X, q.Values.Y },
            { q.Values.Y, -q.Values.X, q.Values.W, q.Values.Z },
            { -q.Values.X, -q.Values.Y, -q.Values.Z, q.Values.W } });
            Matrix b = new Matrix(new float[4, 4] {
            { q.Values.W, q.Values.Z, -q.Values.Y, -q.Values.X },
            { -q.Values.Z, q.Values.W, q.Values.X, -q.Values.Y },
            { q.Values.Y, -q.Values.X, q.Values.W, -q.Values.Z },
            { q.Values.X, q.Values.Y, q.Values.Z, q.Values.W } });
            return a * b;
        }
    }
}
