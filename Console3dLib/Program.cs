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
                { 1f, 0f, 0f, 10f },
                { 0f, 1f, 0f, 10f},
                { 0f, 0f, 1f, 10f},
                { 0f, 0f, 0f, 1f}
            });


            Matrix scale = Matrix.IdentityMatrix;

            Matrix b = Matrix.FromVector4(new Vector4(10, 0, 0, 1));

            Matrix rot = Quaternion.ToRotationMatrix(Quaternion.FromEulerAngles(new Vector3(0, 90, 0)));

            Matrix c = a * b;
            MatrixDisplay(a);
            MatrixDisplay(scale);
            MatrixDisplay(a*(rot*(scale*b)));
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
