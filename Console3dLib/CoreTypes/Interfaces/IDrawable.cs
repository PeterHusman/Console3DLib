using Console3dLib.CoreTypes.DrawingTypes;
using Console3dLib.CoreTypes.WorldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes.Interfaces
{
    public interface IDrawable : IObject
    {
        Triangle[] Triangles { get; set; }
        Vector3 Scalar { get; set; }
        Texture UVTexture { get; set; }
        /// <summary>
        /// Maps the polygon index to the position and size of the texture. (x, y, width, height)
        /// </summary>
        Dictionary<int, Vector4> UVMapping { get; set; }
    }
}
