using Console3dLib.CoreTypes.DrawingTypes;
using Console3dLib.CoreTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes.WorldTypes
{
    public class Polyhedron : IDrawable
    {
        /// <summary>
        /// Vertices of the polyhedron, relative to the object's position.
        /// </summary>
        public Vertex[] Vertices { get; set; }
        public Color Color;
        
        public Vector3 Position { get; set; }
        public Vector3 Scalar { get; set; }
        public Quaternion Rotation { get; set; }

        /// <summary>
        /// Returns whether or not two polyhedrons might be colliding.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        //public bool IsCollidingBroadPhase(Collider b)
        //{
            

        //}
    }
}
