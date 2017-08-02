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
                { 0f, 0f, 1f, 5f},
                { 0f, 0f, 0f, 1f}
            });

            Matrix b = new Matrix(new float[,]
                {
                    { 0f },
                    { 5f },
                    { 10f },
                    { 1f }
                }
             );

            Matrix c = a * b;
            MatrixDisplay(a);
            MatrixDisplay(b);
            MatrixDisplay(c);
            Console.Write("\n\n\n");
            MatrixDisplay(Quaternion.ToRotationMatrix(Quaternion.FromEulerAngles(new Vector3d(90,0,0))));
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
