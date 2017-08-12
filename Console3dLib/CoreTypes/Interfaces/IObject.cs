using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes.Interfaces
{
    public interface IObject
    {
        Vector3 Position { get; set; }
        
        Quaternion Rotation { get; set; }
    }
}
