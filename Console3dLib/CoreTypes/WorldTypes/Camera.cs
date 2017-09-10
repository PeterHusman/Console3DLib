using Console3dLib.CoreTypes;
using Console3dLib.CoreTypes.MathTypes;
using Console3dLib.CoreTypes.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Console3dLib.CoreTypes.WorldTypes;

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

            //ProjectionMatrix[3, 3] = 1;
        }

        public void UpdateViewMatrix()
        {
            Matrix rot = Quaternion.ToRotationMatrix(Rotation);
            Matrix trans = Matrix.TranslationMatrix(Position);
            Matrix scale = Matrix.IdentityMatrix;
            ViewMatrix = (trans * (rot * scale));
        }

        public Camera(float fieldOfViewY, float aspectRatio, float nearClippingZ, float farClippingZ)
        {
            UpdateProjection(fieldOfViewY, aspectRatio, nearClippingZ, farClippingZ);
        }

        public void Render(IDrawable[] objsToRender)
        {
            //Temp: store vertices in list, order by descending Z's, draw vertices in order -- NOT FINAL
            List<Polygon> polygons = new List<Polygon>();
            for(int i = 0; i < objsToRender.Length; i++)
            {
                Matrix modelMatrix = Matrix.RoundValues(Matrix.TranslationMatrix(objsToRender[i].Position)*(Quaternion.ToRotationMatrix(objsToRender[i].Rotation)*Matrix.ScalarMatrix(new Vector4(objsToRender[i].Scalar.X, objsToRender[i].Scalar.Y, objsToRender[i].Scalar.Z, 1) )),-1);
                Matrix mvp = ProjectionMatrix * (ViewMatrix * modelMatrix);
                for (int p = 0; p < objsToRender[i].Polygons.Length; p++)
                {
                    List<Vertex> vertices = new List<Vertex>();
                    for (int v = 0; v < objsToRender[i].Polygons[p].Vertices.Length; v++)
                    {
                        vertices.Add(new Vertex(fromMatrix(mvp * Matrix.FromVector3(objsToRender[i].Polygons[p].Vertices[v].Position))));
                    }
                    polygons.Add(new Polygon(vertices.ToArray()));
                }
            }
            IOrderedEnumerable<Polygon> orderPolys = polygons.OrderByDescending(z);
            StringBuilder screenOutput = new StringBuilder();
            for (int y = 0; y < Console.BufferHeight; y++)
            {
                Console.Out.Flush();
                ;

                for (int x = 0; x < Console.BufferWidth; x++)
                {
                    Console.Write('█');
                    for (int i = 0; i < orderPolys.Count(); i++)
                    {
                        
                        if (!orderPolys.ElementAt(i).PointInside2DXY(new Vector2(x,Console.BufferHeight-y)))
                        {
                            //Console.ForegroundColor = ConsoleColor.White;
                            screenOutput.Append('█');
                        }
                        else
                        {
                            screenOutput.Append('█');
                        }
                    }
                }
                //screenOutput.Append('\n');
            }
            //Console.Write(screenOutput.ToString());
        }

        private Vector3 fromMatrix(Matrix threeByOne)
        {
            return new Vector3(threeByOne[0,0], threeByOne[1,0], threeByOne[2,0]);
        }

        private float z(Polygon p)
        {
            float z = float.MaxValue;
            foreach(Vertex v in p.Vertices)
            {
                if(v.Position.Z <= z)
                {
                    z = v.Position.Z;
                }
            }
            return z;
        }
    }
}