using Console3dLib.CoreTypes;
using Console3dLib.CoreTypes.Interfaces;
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

        public List<IObject> Objects;

        public World(Camera mainCamera)
        {
            MainCamera = mainCamera;
        }
        public void Update()
        {

        }
        public void Draw()
        {
            MainCamera.Render(Objects);
        }
    }
}
