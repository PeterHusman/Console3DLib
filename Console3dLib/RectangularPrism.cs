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
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Size;
        public ConsoleColor Color;

        public RectangularPrism(Vector3 position, Vector3 rotation, Vector3 size, ConsoleColor color)
        {
            Position = position;
            Rotation = rotation;
            Size = size;
            Color = color;
        }
    }
}
