using Console3dLib.CoreTypes.DrawingTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes.WorldTypes
{
    [Obsolete("Use Triangles instead")]
    public class Polygon
    {
        public Vertex[] Vertices { get; set; }
        public bool PointInside2DXY(Vector2 point)
        {
            //float isLeft(Vector2 pt, Vector2 endPoint1, Vector2 endPoint2)
            //{
            //    return (endPoint2.X - endPoint1.X) * (pt.Y - endPoint1.Y) - (pt.X - endPoint1.X) * (endPoint2.Y - endPoint1.Y);
            //}
            int countingNum = 0;
            Vertex[] V = new Vertex[Vertices.Length + 1];
            for (int i = 0; i < Vertices.Length; i++)
            {
                V[i] = Vertices[i];
            }
            V[Vertices.Length] = Vertices[0];
            for (int i = 0; i < Vertices.Length; i++)
            {
                if (((V[i].Position.Y <= point.Y) && (V[i + 1].Position.Y > point.Y)) || ((V[i].Position.Y > point.Y) && (V[i + 1].Position.Y <= point.Y)))
                {
                    float interX = (point.Y - V[i].Position.Y) / (V[i + 1].Position.Y - V[i].Position.Y);
                    if(point.X < V[i].Position.X + interX * (V[i+1].Position.X - V[i].Position.X))
                    {
                        countingNum++;
                    }
                }
            }
            return (countingNum & 1) == 1;
        }
        public Polygon()
        {

        }
        public Polygon(Vertex[] vertices)
        {
            Vertices = vertices;

        }
    }
}
