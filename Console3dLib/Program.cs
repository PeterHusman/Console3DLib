using Console3dLib.CoreTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib
{
    class Program
    {
        static void Main(string[] args)
        {

            //World world = new World();
            Matrix a = new Matrix(new float[,] {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f},
                { 0f, 0f, 1f, 0f},
                { 0f, 0f, 0f, 1f}
            });


            Matrix scale = Matrix.IdentityMatrix;

            Matrix b = Matrix.FromVector3(new Vector3(10, 0, 0));

            Matrix rot = Quaternion.ToRotationMatrix(Quaternion.FromEulerAngles(new Vector3(0,0,(float)Math.PI/2f)))/*Quaternion.FromEulerAngles(new Vector3(0, 90, 0))*/;

            Matrix c = a * b;
            MatrixDisplay(rot);

            MatrixDisplay(Matrix.FromVector3(Quaternion.ToEulerAngles(Quaternion.FromEulerAngles(new Vector3(0, (float)Math.PI / 2f, 0)))));

            MatrixDisplay(Matrix.FromVector4(Quaternion.FromEulerAngles(new Vector3(0, (float)Math.PI/2, 0)).Values));
            MatrixDisplay(b);
            MatrixDisplay(Matrix.RoundValues(rot*b,-3));
            Console.Write("\n\n\n");

            Console.ReadKey();



        }

        private static void MatrixDisplay(Matrix a)
        {
            for (int y = 0; y < a.Rows; y++)
            {
                for (int x = 0; x < a.Columns; x++)
                {
                    Console.Write(a[y, x].ToString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
