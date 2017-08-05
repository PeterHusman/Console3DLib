﻿using Console3dLib.CoreTypes;
using Console3dLib.CoreTypes.MathTypes;
using Console3dLib.CoreTypes.RenderTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib
{
    public class Camera : IObject
    {
        public Vector3 Position
        {
            get;
            set;
        }
        public Quaternion Rotation
        {
            get;
            set;
        }

        public float NearClippingPaneDistance { get; private set; }
        public float FarClippingPaneDistance { get; private set; }
        public float FOVY { get; private set; }
        public float FOVX { get; private set; }

        public Matrix ViewMatrix { get; private set; }

        public Matrix ProjectionMatrix { get; private set; }

        public float Zoom = 10f;

        /// <summary>
        /// Updates the projection matrix
        /// </summary>
        /// <param name="fieldOfViewY">The y-axis field of view in radians.</param>
        /// <param name="aspectRatio">The ratio of x-axis field of view to y-axis field of view. Example: 1280/960</param>
        /// <param name="nearClippingZ">The distance to the near clipping plane</param>
        /// <param name="farClippingZ">The distance to the far clipping plane</param>
        public void UpdateProjection(float fieldOfViewY, float aspectRatio, float nearClippingZ, float farClippingZ)
        {
            NearClippingPaneDistance = nearClippingZ;
            FarClippingPaneDistance = farClippingZ;
            FOVY = fieldOfViewY;
            FOVX = aspectRatio * fieldOfViewY;

            ProjectionMatrix = new Matrix(new float[4, 4]);
            float tanOfHalfFovY = (float)Math.Tan(fieldOfViewY / 2);

            ProjectionMatrix[0, 0] = 1 / (aspectRatio * tanOfHalfFovY);
            ProjectionMatrix[1, 1] = 1 / tanOfHalfFovY;
            ProjectionMatrix[2, 2] = -(farClippingZ + nearClippingZ) / (farClippingZ-nearClippingZ);
            ProjectionMatrix[2, 3] = -1;
            ProjectionMatrix[3, 2] = -(2 * nearClippingZ * farClippingZ) / (farClippingZ - nearClippingZ);
        }


        public void Render()
        {
            
            
        }
    }
}
