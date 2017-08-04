using Console3dLib.CoreTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib
{
    public class Camera
    {
        public Vector3 Position
        {
            get;
            set;
        }
        public Vector3 Rotation
        {
            get;
            set;
        }

        public float Zoom = 10f;

        public void Render()
        {
            

            
        }
    }
}
