using Console3dLib.CoreTypes.DrawingTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes.WorldTypes
{
    public class Polygon
    {
        public Vertex[] Vertices { get; set; }
        public Vector3 Position { get; set; }
    }
}
