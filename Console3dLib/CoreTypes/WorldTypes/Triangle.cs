using Console3dLib.CoreTypes.DrawingTypes;
using Console3dLib.CoreTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes.WorldTypes
{
    public class Triangle : IObject
    {
        public Vertex[] Vertices = new Vertex[2];
        public Color Color = new Color();
        /// <summary>
        /// The position of the first vertex of the triangle.
        /// </summary>
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
    }
}
