﻿using Console3dLib.CoreTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes.WorldTypes
{
    public class Vertex : IObject
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
    }
}
