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
        Vertex[] Vertices { get; set; }
        Vector3 Scalar { get; set; }
        //Texture
    }
}
