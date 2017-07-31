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
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine(c.ToString());
            Console.ReadKey();



        }
    }
}
