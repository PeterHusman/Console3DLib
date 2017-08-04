using Console3dLib.CoreTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib
{
    class World
    {
        public Camera MainCamera;

        public RectangularPrism Cube = new RectangularPrism(Vector3.One*0,Vector3.One*0,Vector3.One,ConsoleColor.Red);
        public World()
        {
            
        }
        public void Update()
        {

        }
        public void Draw()
        {
            MainCamera.Render();
        }
    }
}
