using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes.WorldTypes
{
    public class Triangle
    {
        public Vertex[] Vertices;

        public Triangle(Vertex[] vertices)
        {
            Vertices = new Vertex[3];
            Vertices[0] = vertices[0];
            Vertices[1] = vertices[1];
            Vertices[2] = vertices[2];
        }

        public Triangle()
        {
            Vertices = new Vertex[3];
        }

        public bool PointInside2DXY(Vector2 point)
        {
            float denominator = ((Vertices[1].Position.Y - Vertices[2].Position.Y) * (Vertices[0].Position.X - Vertices[2].Position.X) + (Vertices[2].Position.X - Vertices[1].Position.X) * (Vertices[0].Position.Y - Vertices[2].Position.Y));
            float a = ((Vertices[1].Position.Y - Vertices[2].Position.Y) * (point.X - Vertices[2].Position.X) + (Vertices[2].Position.X - Vertices[1].Position.X) * (point.Y - Vertices[2].Position.Y)) / denominator;
            float b = ((Vertices[2].Position.Y - Vertices[0].Position.Y) * (point.X - Vertices[2].Position.X) + (Vertices[0].Position.X - Vertices[2].Position.X) * (point.Y - Vertices[2].Position.Y)) / denominator;
            float c = 1 - a - b;
            return 0 <= a && a <= 1 && 0 <= b && b <= 1 && 0 <= c && c <= 1;
        }
    }
}
