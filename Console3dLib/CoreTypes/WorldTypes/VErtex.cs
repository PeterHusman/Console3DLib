using Console3dLib.CoreTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes.WorldTypes
{
    public class Vertex
    {
        public Vector3 Position { get; set; }

        public Vertex(Vector3 position)
        {
            Position = position;
        }
        public Vertex(float x, float y, float z)
        {
            Position = new Vector3(x,y,z);
        }
        //public Quaternion Rotation { get; set; }
    }
}
