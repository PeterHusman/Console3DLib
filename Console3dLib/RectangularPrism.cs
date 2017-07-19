using Console3dLib.CoreTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib
{
    class RectangularPrism
    {
        public Vector3d Position;
        public Vector3d Rotation;
        public Vector3d Size;
        public ConsoleColor Color;

        public RectangularPrism(Vector3d position, Vector3d rotation, Vector3d size, ConsoleColor color)
        {
            Position = position;
            Rotation = rotation;
            Size = size;
            Color = color;
        }
    }
}
