using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes.DrawingTypes
{
    public class Color
    {
        private Dictionary<ConsoleColor, Vector3> consoleToHSV = new Dictionary<ConsoleColor, Vector3>() { { ConsoleColor.Black, new Vector3(0,0,0) }, { ConsoleColor.DarkBlue, new Vector3(240, 100, 54.9f) }, { ConsoleColor.DarkGreen, new Vector3(123.18f, 100, 51.76f) }, { ConsoleColor.DarkCyan, new Vector3(176.82f, 100, 51.76f) }, { ConsoleColor.DarkRed, new Vector3(1.01f, 99.17f, 47.06f) }, { ConsoleColor.DarkMagenta, new Vector3(302.5f, 97.56f, 48.24f) }, { ConsoleColor.DarkYellow, new Vector3(59.51f, 99.19f, 48.63f) }, { ConsoleColor.Gray, new Vector3(0, 0, 76.08f) }, { ConsoleColor.DarkGray, new Vector3(37.5f, 6.25f, 50.2f) }, { ConsoleColor.Blue, new Vector3(240, 100, 98.82f) }, { ConsoleColor.Green, new Vector3(118.82f, 100, 100f) }, { ConsoleColor.Cyan, new Vector3(178.8f, 99.2f, 98.43f) }, { ConsoleColor.Red, new Vector3(1.01f, 100, 93.33f) }, { ConsoleColor.Magenta, new Vector3(300, 99.61f, 100f) }, { ConsoleColor.Yellow, new Vector3(59.52f, 97.64f, 99.61f) }, { ConsoleColor.White, new Vector3(90, 1.58f, 99.22f) } };

        public float H { get { return HSV.X; } set { HSV.X = value; } }
        public float S { get { return HSV.Y; } set { HSV.Y = value; } }
        public float V { get { return HSV.Z; } set { HSV.Z = value; } }

        public Vector3 HSV;

        public static Color FromRGB(Vector3 rgb)
        {
            System.Drawing.Color systemColor = System.Drawing.Color.FromArgb((int)rgb.X,(int)rgb.Y,(int)rgb.Z);
            return new Color(systemColor.GetHue(),systemColor.GetSaturation(),systemColor.GetBrightness() * 240);
        }

        public ConsoleColor NearestConsoleColor()
        {
            float leastDistance = float.MaxValue;
            ConsoleColor leastDistColor = ConsoleColor.Black;

            foreach(ConsoleColor key in consoleToHSV.Keys.ToArray())
            {
                Vector3 hsv = consoleToHSV[key];
                float distance = (H-hsv.X)* (H - hsv.X) + (S - hsv.Y) * (S - hsv.Y) + (V - hsv.Z) * (V - hsv.Z);
                if(distance < leastDistance)
                {
                    leastDistance = distance;
                    leastDistColor = key;
                }
            }

            return leastDistColor;
        }

        public Color(float h, float s, float v)
        {
            HSV = new Vector3(h,s,v);
        }

    }
}
